namespace ToDoList_v1
{
    public class Issue
    {
        public Issue(string title)
        {
            Title = title;
            DateTime = DateTime.Now;
            Status = Status.Новое;
        }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public Status Status { get; set; }

    }
}