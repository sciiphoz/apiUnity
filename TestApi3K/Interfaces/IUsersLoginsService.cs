using Microsoft.AspNetCore.Mvc;
using TestApi3K.Requests;

namespace TestApi3K.Interfaces
{
    public interface IUsersLoginsService
    {
        Task<IActionResult> GetAllUsersAsync();
        Task<IActionResult> GetUserAsync(int userId);
        Task<IActionResult> CreateNewUserAsync(CreateNewUser newUser);
        Task<IActionResult> LoginAsync(LoginModel user);
        Task<IActionResult> AddScoreAsync(int userId, int value, int lvl);
    }
}
