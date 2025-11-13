using Microsoft.AspNetCore.Mvc;
using TestApi3K.Interfaces;
using TestApi3K.Requests;
using TestApi3K.Service;

namespace TestApi3K.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersRecordController
    {
        private readonly IRecordService _recordService;

        public UsersRecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        [Route("getAllRecords/{userId}")]
        public async Task<IActionResult> GetAllRecords(int userId)
        {
            return await _recordService.GetAllRecordsAsync(userId);
        }

        [HttpPost]
        [Route("achievement/{achievementId}/addTo/{userId}")]
        public async Task<IActionResult> CreateNewUser(int achievementId, int userId)
        {
            return await _recordService.AddRecordAsync(achievementId, userId);
        }
    }
}
