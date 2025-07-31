using AutoMapper;
using MTS.Application.DTOs.Theses;

using MTS.Application;
using MTS.Domain.Entities;

public class ThesisService : IThesisService
{
    private readonly IThesisRepository _repository;
    private readonly IMapper _mapper;

    public ThesisService(IThesisRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ThesisDto> GetByIdAsync(int id)
    {
        var thesis = await _repository.GetByIdAsync(id);
        return _mapper.Map<ThesisDto>(thesis);
    }

    public async Task<ThesisDto> CreateAsync(CreateThesisDto dto)
    {
        var thesis = _mapper.Map<ThesisTopic>(dto);
        await _repository.AddAsync(thesis);
        return _mapper.Map<ThesisDto>(thesis);
    }

    public async Task UpdateAsync(UpdateThesisDto dto)
    {
        var thesis = await _repository.GetByIdAsync(dto.Id);
        _mapper.Map(dto, thesis);
        await _repository.UpdateAsync(thesis);
    }

    public Task AssignJuryAsync(int id, AssignJuryDto dto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStatusAsync(int id, UpdateThesisStatusDto dto)
    {
        throw new NotImplementedException();
    }
}