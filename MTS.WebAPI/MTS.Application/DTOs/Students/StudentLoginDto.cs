using System.ComponentModel.DataAnnotations;

namespace MTS.Application.DTOs.Students
{
    public class StudentLoginDto
    {
        [Required]
        public string StudentNumber { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
