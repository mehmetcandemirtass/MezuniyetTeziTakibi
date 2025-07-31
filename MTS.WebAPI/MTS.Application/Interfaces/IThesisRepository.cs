// MTS.Application/Interfaces/IThesisRepository.cs
using MTS.Application.Interfaces;
using MTS.Domain.Entities;

public interface IThesisRepository : IGenericRepository<ThesisTopic>
{
    Task<ThesisTopic> GetByIdWithDetailsAsync(int id);
    Task<ThesisTopic> GetByIdWithJuryAsync(int id);
    Task UpdateStatusAsync(int thesisId, string status);
    Task AssignJuryMembersAsync(int thesisId, IEnumerable<int> juryMemberIds);
}