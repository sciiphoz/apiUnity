using Microsoft.AspNetCore.Mvc;
using TestApi3K.Requests;

namespace TestApi3K.Interfaces
{
    public interface IUsersLoginsService
    {
        Task<IActionResult> GetAllUsersAsync();
        Task<IActionResult> GetUserAsync(int userId);
        Task<IActionResult> GetAllSkinsAsync();
        Task<IActionResult> GetUsersSkinsAsync(int userId);
        Task<IActionResult> CreateNewUserAsync(CreateNewUser newUser);
        Task<IActionResult> LoginAsync(LoginModel user);
        Task<IActionResult> AddCurrencyAsync(int userId, int value);
        Task<IActionResult> DepleteCurrencyAsync(int userId, int value);
        Task<IActionResult> BuySkinAsync(int userId, int skinId);
    }
}
