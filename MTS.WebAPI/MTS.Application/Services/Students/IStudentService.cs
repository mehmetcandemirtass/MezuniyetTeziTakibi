using MTS.Application.DTOs.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.Application.Services.Students
{
    public interface IStudentService
    {
        Task <List<StudentDto>> GetAllStudentsAsync();
        Task  <StudentDto> GetStudentByIdAsync(int id);
        Task CreateStudent(CreateStudentDto studentDto);
        Task UpdateStudentAsync(UpdateStudentDto studentDto);
        Task DeleteStudentAsync(int id);
        Task<StudentDto> AuthenticateAsync(string studentNumber, string password);
        object Get_studentRepository();
    }

}
