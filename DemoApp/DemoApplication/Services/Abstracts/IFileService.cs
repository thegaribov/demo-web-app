using DemoApplication.Contracts.Email;
using DemoApplication.Contracts.File;

namespace DemoApplication.Services.Abstracts
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile formFile, UploadDirectory uploadDirectory);
    }
}
