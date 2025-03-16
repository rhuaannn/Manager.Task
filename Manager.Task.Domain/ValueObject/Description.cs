namespace Manager.Task.Domain.ValueObject
{
    public class Description
    {
        public string DescriptionTask { get; private set; } = string.Empty;

        public Description() { }

        public Description(string description)
        {
            if (!IsValid(description))
            {
                throw new ArgumentException("Descrição inválida.", nameof(description));
            }
            DescriptionTask = description;
        }

        public bool IsValid(string description)
        {
            return !string.IsNullOrEmpty(description);
        }

        public override string ToString() => DescriptionTask;
        public static implicit operator string(Description description) => description?.DescriptionTask;
        public static implicit operator Description(string description) => new Description(description);


    }
}