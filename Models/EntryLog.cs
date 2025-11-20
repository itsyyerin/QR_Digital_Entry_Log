using System;

namespace QR_Digital_Entry_Log.Models
 
{
    public class EntryLog
    {
        public int Id { get; set; }
        public string UserName { get; set; } //이름
        public string Phone { get; set; } //전화번호
        public int LocationId { get; set; } //장소 id
        public DateTime VisitedAt { get; set; } = DateTime.Now; //방문시간
    }
}
