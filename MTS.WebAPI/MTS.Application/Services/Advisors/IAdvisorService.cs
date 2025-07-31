using MTS.Application.DTOs.Advisors;
using MTS.Application.DTOs.Students;
using MTS.Domain.Entities;

namespace MTS.Application.Interfaces.Services
{
    public interface IAdvisorService
    {
        Task<IEnumerable<Advisor>> GetAllAsync();
        Task<Advisor> GetByIdAsync(int id);
        Task <AdvisorDto> AddAsync(CreateAdvisorDto entity);
        Task UpdateAsync(UpdateAdvisorDto entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(AdvisorDto entity);
        Task<bool> ExistsAsync(int id);
        Task<List<Advisor>> GetAllAdvisorsWithStudents();
        Task<Advisor> GetAdvisorDetails(int id);
        Task<AdvisorDto?> AuthenticateAsync(string email, string password);
        Task<List<StudentDto>> GetStudentsByAdvisorIdAsync(int advisorId);
    }
}
