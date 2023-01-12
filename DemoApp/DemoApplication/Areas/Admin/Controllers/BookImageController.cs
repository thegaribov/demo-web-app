using DemoApplication.Areas.Admin.ViewModels.BookImage;
using DemoApplication.Contracts.File;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace DemoApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/books")]
    [Authorize(Roles = "admin")]
    public class BookImageController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;

        public BookImageController(
            DataContext dataContext,
            IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        #region List

        [HttpGet("{bookId}/image/list", Name = "admin-book-image-list")]
        public async Task<IActionResult> ListAsync([FromRoute] int bookId)
        {
            var book = await _dataContext.Books
                .Include(b => b.BookImages)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book is null)
            {
                return NotFound();
            }

            var model = new BookImagesViewModel { BookId = book.Id };

            model.Images = book.BookImages!.Select(bi => new BookImagesViewModel.ListItem
            {
                Id = bi.Id,
                ImageUrL = _fileService.GetFileUrl(bi.ImageNameInFileSystem, UploadDirectory.Book),
                CreatedAt = bi.CreatedAt
            }).ToList();

            return View(model);
        }

        #endregion

        #region Add

        [HttpGet("{bookId}/image/add", Name = "admin-book-image-add")]
        public async Task<IActionResult> AddAsync()
        {
            return View(new AddViewModel());
        }

        [HttpPost("{bookId}/image/add", Name = "admin-book-image-add")]
        public async Task<IActionResult> AddAsync([FromRoute] int bookId, [FromForm] AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var book = await _dataContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            if (book is null)
            {
                return NotFound();
            }

            var imageNameInSystem = await _fileService.UploadAsync(model.Image, UploadDirectory.Book);

            var bookImage = new BookImage
            {
                Book = book,
                ImageName = model.Image.FileName,
                ImageNameInFileSystem = imageNameInSystem
            };

            await _dataContext.AddAsync(bookImage);

            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-book-image-list", new { bookId = bookId });
        }

        #endregion


        #region Delete

        [HttpPost("{bookId}/image/{bookImageId}/delete", Name = "admin-book-image-delete")]
        public async Task<IActionResult> DeleteAsync(int bookId, int bookImageId)
        {
            var bookImage = await _dataContext.BookImages
                .FirstOrDefaultAsync(bi => bi.Id == bookImageId && bi.BookId == bookId);
            if (bookImage is null)
            {
                return NotFound();
            }

            await _fileService.DeleteAsync(bookImage.ImageNameInFileSystem, UploadDirectory.Book);

            _dataContext.BookImages.Remove(bookImage);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-book-image-list", new { bookId = bookId });
        }

        #endregion
    }
}
