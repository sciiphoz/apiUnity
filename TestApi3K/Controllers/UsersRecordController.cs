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
        [Route("getAllAchievements")]
        public async Task<IActionResult> GetAllAchievements()
        {
            return await _recordService.GetAllAchievementsAsync();
        }

        [HttpGet]
        [Route("getAllRecords/{userId}")]
        public async Task<IActionResult> GetAllRecords(int userId)
        {
            return await _recordService.GetAllRecordsAsync(userId);
        }

        [HttpPost]
        [Route("record/create")]
        public async Task<IActionResult> CreateNewUser(Record newRecord)
        {
            return await _recordService.AddRecordAsync(newRecord);
        }
    }
}
