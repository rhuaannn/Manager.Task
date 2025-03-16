using Manager.Task.Domain.Task;

namespace Manager.Task.Domain.ValueObject
{
    public class Title
    {
        public string TitleTask { get; private set; } = string.Empty;

        public Title(string title)
        {
            if (!IsValid(title))
            {
                throw new Exception("Title inválido!");
            }
            TitleTask = title;
        }

        private Title()
        {
        }
        public bool IsValid(string title)
        {
            return !string.IsNullOrEmpty(title);
        }
        public override string ToString() => TitleTask;

        public static implicit operator string(Title title) => title?.TitleTask;
        public static implicit operator Title(string title) => new Title(title);


    }
}
