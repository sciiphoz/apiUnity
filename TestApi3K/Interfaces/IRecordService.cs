using Microsoft.AspNetCore.Mvc;
using TestApi3K.Requests;
using TestApi3K.Service;

namespace TestApi3K.Interfaces
{
    public interface IRecordService
    {
        Task<IActionResult> GetAllRecordsAsync(int userId);
        Task<IActionResult> AddRecordAsync(int achievementId, int userId);
    }
}
