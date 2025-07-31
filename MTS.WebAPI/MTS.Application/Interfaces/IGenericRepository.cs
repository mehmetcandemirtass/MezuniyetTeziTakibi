using System.Collections.Generic;
using System.Threading.Tasks;

using MTS.Domain.Entities; // Assuming you have a namespace for your entities

namespace MTS.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity); // void -> Task olarak değiştirildi
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(T entity);
        Task<bool> ExistsAsync(int id);
        Task<Student> GetByStudentNumberAsync(int studentNumber);
    }
}
