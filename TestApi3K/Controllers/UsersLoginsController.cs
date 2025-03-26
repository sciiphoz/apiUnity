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

        [HttpGet]
        [Route("getAllSkins")]
        public async Task<IActionResult> GetAllSkins()
        {
            return await _userLoginService.GetAllSkinsAsync();
        }

        [HttpGet]
        [Route("getUsersSkins")]
        public async Task<IActionResult> GetUsersSkins(int userId)
        {
            return await _userLoginService.GetUsersSkinsAsync(userId);
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
        [Route("user/{userId}/addCurrency/{value}")]
        public async Task<IActionResult> AddCurrency(int userId, int value)
        {
            return await _userLoginService.AddCurrencyAsync(userId, value);
        }
        [HttpPut]
        [Route("user/{userId}/depleteCurrency/{value}")]
        public async Task<IActionResult> DepleteCurrency(int userId, int value)
        {
            return await _userLoginService.DepleteCurrencyAsync(userId, value);
        }
        [HttpPut]
        [Route("user/{userId}/buySkin/{skinId}")]
        public async Task<IActionResult> BuySkin(int userId, int skinId)
        {
            return await _userLoginService.BuySkinAsync(userId, skinId);
        }
    }
}
