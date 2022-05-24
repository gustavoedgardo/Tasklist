using System;

namespace Tasklist.Api.Models
{
    public class TaskLog
    {
        public int Id { get; set; }

        public int TaskId { get; set; }

        public DateTime ActionDate { get; set; }

        public string Action { get; set; }
    }
}
