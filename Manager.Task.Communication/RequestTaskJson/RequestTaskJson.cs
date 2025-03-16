namespace Manager.Task.Communication.RequestTaskJson
{
    public class RequestRegisterJson
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.Now;


        

    }
}
