using MTS.Domain.Entities;

namespace MTS.Application.Interfaces;


public interface IAdvisorRepository : IGenericRepository<Advisor>
{
    Task<List<Advisor>> GetAdvisorsWithStudentsAsync();
    Task<Advisor> GetAdvisorByIdWithStudentsAsync(int id);
    Task<Advisor> GetAdvisorByEmailAsync(string email);
}
