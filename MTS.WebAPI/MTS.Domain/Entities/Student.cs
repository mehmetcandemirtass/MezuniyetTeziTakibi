namespace MTS.Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int AdvisorId { get; set; } // Foreign key property
    public Advisor Advisor { get; set; } // Navigation property
    public ICollection<Report> Reports { get; set; }
    public ICollection<Message> Messages { get; set; }
  
    public string Password { get; set; }
    public string StudentNumber { get; set; }
}
