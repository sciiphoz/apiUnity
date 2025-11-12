using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;
using TestApi3K.Interfaces;
using TestApi3K.Requests;

namespace TestApi3K.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersLoginsController
    {
        private readonly IUsersLoginsService _userLoginService;

        public UsersLoginsController(IUsersLoginsService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return await _userLoginService.GetAllUsersAsync();
        }

        [HttpGet]
        [Route("getUser/{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            return await _userLoginService.GetUserAsync(userId);
        }

        [HttpPost]
        [Route("user/register")]
        public async Task<IActionResult> CreateNewUser(CreateNewUser newUser)
        {
            return await _userLoginService.CreateNewUserAsync(newUser);
        }

        [HttpPost]
        [Route("user/login")]
        public async Task<IActionResult> Login(LoginModel user)
        {
            return await _userLoginService.LoginAsync(user);
        }

        [HttpPut]
        [Route("user/{userId}/score/{value}/level/{lvl}")]
        public async Task<IActionResult> AddScore(int userId, int value, int lvl)
        {
            return await _userLoginService.AddScoreAsync(userId, value, lvl);
        }
    }
}
