namespace demo_taller.Models.Entities
{
    public class Message
    {
        private string name;
        private string email;
        private string subject;
        private string content;

        public Message()
        {
        }

        public Message(string name, string email, string subject, string content)
        {
            Name = name;
            Email = email;
            Subject = subject;
            Content = content;
        }

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Content { get => content; set => content = value; }
    }
}
