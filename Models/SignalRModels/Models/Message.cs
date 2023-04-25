namespace MyMessager.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateOfSend { get; set; }
        public User User { get; set; }
    }
}
