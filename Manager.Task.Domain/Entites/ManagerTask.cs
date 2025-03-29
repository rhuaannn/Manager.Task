using System.ComponentModel.DataAnnotations;
using Manager.Task.Domain.Enums;
using Manager.Task.Domain.ValueObject;

namespace Manager.Task.Domain.Task
{
    public class ManagerTask
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Title Title { get; set; }

        public Description Description { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public Status Status { get; set; } = Status.Pending;

        public Priority Priority { get; set; } = Priority.Low;
 
        public ManagerTask(string title, string description, DateTime date, Status status, Priority priority)
        {
            Title = new Title(title);
            Description = new Description(description);
            Date = date;
            Status = status;
            Priority = priority;
        }

        public ManagerTask()
        {
            
        }
    }


}