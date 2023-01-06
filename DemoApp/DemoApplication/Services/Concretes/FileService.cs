using DemoApplication.Contracts.File;
using DemoApplication.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DemoApplication.Services.Concretes
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService>? _logger;

        public FileService(ILogger<FileService>? logger)
        {
            _logger = logger;
        }

        public async Task<string> UploadAsync(IFormFile formFile, UploadDirectory uploadDirectory)
        {
            string directoryPath = GetUploadDirectory(uploadDirectory);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var imageNameInSystem = GenerateUniqueFileName(formFile.FileName);
            var filePath = Path.Combine(directoryPath, imageNameInSystem);

            try
            {
                using FileStream fileStream = new FileStream(filePath, FileMode.Create);
                await formFile.CopyToAsync(fileStream);
            }
            catch (Exception e)
            {
                _logger!.LogError(e, "Error occured in file service");

                throw;
            }

            return imageNameInSystem;
        }

        public async Task DeleteAsync(string? fileName, UploadDirectory uploadDirectory)
        {
            var deletePath = Path.Combine(GetUploadDirectory(uploadDirectory), fileName);

            await Task.Run(() => File.Delete(deletePath));
        }

        private string GetUploadDirectory(UploadDirectory uploadDirectory)
        {
            string startPath = Path.Combine("wwwroot", "client", "custom-files");

            switch (uploadDirectory)
            {
                case UploadDirectory.Book:
                    return Path.Combine(startPath, "books");
                default:
                    throw new Exception("Something went wrong");
            }
        }
            
        private string GenerateUniqueFileName(string fileName)
        {
            return $"{Guid.NewGuid()}{Path.GetExtension(fileName)}";
        }

        public string GetFileUrl(string? fileName, UploadDirectory uploadDirectory)
        {
            string initialSegment = "client/custom-files/";

            switch (uploadDirectory)
            {
                case UploadDirectory.Book:
                    return $"{initialSegment}/books/{fileName}";
                default:
                    throw new Exception("Something went wrong");
            }
        }
    }
}
