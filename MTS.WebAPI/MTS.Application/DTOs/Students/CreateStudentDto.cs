namespace MTS.Application.DTOs.Students;

public class CreateStudentDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public int StudentNumber { get; set; }
    public string Password { get; set; }
}
