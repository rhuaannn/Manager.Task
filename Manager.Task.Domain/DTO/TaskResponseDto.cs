using System;
using Manager.Task.Domain.Enums;

namespace Manager.Task.Domain.DTO
{
    public class TaskResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
    }
}