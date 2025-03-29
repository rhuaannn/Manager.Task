using System;
using Manager.Task.Domain.Enums;

namespace Manager.Task.Domain.DTO
{
    public class TaskDto
    {
        
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Pending;
        public Priority Priority { get; set; } = Priority.Low;
    }
}