namespace MTS.Domain.Entities
{
    public class Advisor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Student> Students { get; set; } 
        public ICollection<Report> Reports { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
