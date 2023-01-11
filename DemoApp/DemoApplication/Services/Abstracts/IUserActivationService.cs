using DemoApplication.Areas.Client.ViewModels.Authentication;
using DemoApplication.Database.Models;

namespace DemoApplication.Services.Abstracts
{
    public interface IUserActivationService
    {
        Task SendActivationUrlAsync(User user); 

    }
}
