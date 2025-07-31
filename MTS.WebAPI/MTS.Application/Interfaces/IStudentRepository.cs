using MTS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.Application.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<List<Student>> GetAllStudentsWithDetailsAsync();
        Task<Student> GetByStudentNumberAsync(string studentNumber); // Dönüş tipi eklendi
        //Task GetByStudentNumberAsync(string v);
    }
}