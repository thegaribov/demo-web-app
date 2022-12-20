using DemoApplication.Areas.Client.ViewModels.Authentication;
using DemoApplication.Database.Models;

namespace DemoApplication.Services.Abstracts
{
    public interface IUserService
    {
        public User CurrentUser { get; }

        Task<bool> CheckPasswordAsync(string? email, string? password);
        Task SignInAsync(Guid id);
        Task SignInAsync(string? email, string? password);
        Task CreateAsync(RegisterViewModel model);
        Task SignOutAsync();

    }
}
