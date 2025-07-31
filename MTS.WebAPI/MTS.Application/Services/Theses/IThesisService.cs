// MTS.Application/Interfaces/IThesisService.cs
using MTS.Application.DTOs.Theses;

public interface IThesisService
{
    Task<ThesisDto> GetByIdAsync(int id);
    Task<ThesisDto> CreateAsync(CreateThesisDto dto);
    Task UpdateAsync(UpdateThesisDto dto);
    Task AssignJuryAsync(int id, AssignJuryDto dto);
    Task UpdateStatusAsync(int id, UpdateThesisStatusDto dto);
}