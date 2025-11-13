using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi3K.DataBaseContext;
using TestApi3K.Interfaces;
using TestApi3K.Model;
using TestApi3K.Requests;

namespace TestApi3K.Service
{
    public class RecordService : IRecordService
    {
        private readonly ContextDb _context;

        public RecordService (ContextDb context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetAllRecordsAsync(int userId)
        {
            var records = await _context.UsersRecord.OrderByDescending(x => x.id_Record).Where(ua => ua.id_User == userId)
                .ToListAsync();

            return new OkObjectResult(new
            {
                records,
                status = true
            });
        }

        public async Task<IActionResult> AddRecordAsync(int achievementId, int userId)
        {
            var record = new UsersRecord()
            {
                id_User = userId,
                id_Achievement = achievementId,
            };

            if (record == null)
            {
                return new ConflictObjectResult(new { status = false });
            }
            else
            {
                await _context.UsersRecord.AddAsync(record);
                await _context.SaveChangesAsync();
                return new OkObjectResult(new { record, status = true });
            }
        }
    }
}
