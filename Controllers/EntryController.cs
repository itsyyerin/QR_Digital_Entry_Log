using Microsoft.AspNetCore.Mvc;
using QR_Digital_Entry_Log.Data;
using QR_Digital_Entry_Log.Models;

namespace QR_Digital_Entry_Log.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class EntryController : ControllerBase
    {
        private readonly AppDbContext _db;

        public EntryController(AppDbContext db)
        {
            _db = db;
        }

        // 1) 테스트용: 더미 데이터 한 줄 넣어보기
        // GET /api/entry/test-insert
        [HttpGet("test-insert")]
        public IActionResult TestInsert()
        {
            var entry = new EntryLog
            {
                UserName = "이예린",
                Phone = "010-7777-3333",
                LocationId = 1
            };

            _db.EntryLogs.Add(entry);
            _db.SaveChanges();

            return Ok(new { message = "테스트 데이터가 저장되었습니다.", id = entry.Id });
        }


        // ✅ 2) 실제용: POST로 JSON 받아서 저장
        // POST /api/entry
        [HttpPost]
        public IActionResult CreateEntry([FromBody] EntryLog entry)
        {
            _db.EntryLogs.Add(entry);
            _db.SaveChanges();

            return Ok(new { message = "출입이 기록되었습니다.", id = entry.Id });
        }
    }
}
