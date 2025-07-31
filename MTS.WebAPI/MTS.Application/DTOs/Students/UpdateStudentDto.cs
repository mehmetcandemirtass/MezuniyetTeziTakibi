namespace MTS.Application.DTOs.Students;

public class UpdateStudentDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string StudentNumber { get; set; }
    public string Password { get; set; }
}
