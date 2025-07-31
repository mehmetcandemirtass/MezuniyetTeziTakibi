using AutoMapper;
using MTS.Application.DTOs.Advisors;
using MTS.Application.DTOs.Students;
using MTS.Application.Interfaces;
using MTS.Application.Interfaces.Services;
using MTS.Domain.Entities;

namespace MTS.Application.Services.Advisors
{
    public class AdvisorService : IAdvisorService
    {
        private readonly IAdvisorRepository _advisorRepository;
        private readonly IMapper _mapper;

        public AdvisorService(IAdvisorRepository advisorRepository, IMapper mapper)
        {
            _advisorRepository = advisorRepository ?? throw new ArgumentNullException(nameof(advisorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Advisor>> GetAllAsync()
        {
            return await _advisorRepository.GetAllAsync();
        }

        public async Task<List<Advisor>> GetAllAdvisorsWithStudents()
        {
            return await _advisorRepository.GetAdvisorsWithStudentsAsync();
        }

        public async Task<Advisor> GetAdvisorDetails(int id)
        {
            return await _advisorRepository.GetAdvisorByIdWithStudentsAsync(id);
        }

        public async Task<Advisor> GetByIdAsync(int id)
        {
            return await _advisorRepository.GetByIdAsync(id);
        }

        public async Task<AdvisorDto> AddAsync(CreateAdvisorDto dto)
        {
            var advisor = _mapper.Map<Advisor>(dto);
            await _advisorRepository.AddAsync(advisor);
            return _mapper.Map<AdvisorDto>(advisor);
        }

        public async Task UpdateAsync(UpdateAdvisorDto dto)
        {
            var advisor = await _advisorRepository.GetByIdAsync(dto.Id);
            if (advisor == null)
                throw new KeyNotFoundException("Advisor not found");

            _mapper.Map(dto, advisor); // Use AutoMapper to update properties
            await _advisorRepository.UpdateAsync(advisor);
        }

        public async Task DeleteAsync(int id)
        {
            await _advisorRepository.DeleteAsync(id);
        }

        public async Task DeleteAsync(AdvisorDto dto)
        {
            var advisor = await _advisorRepository.GetByIdAsync(dto.Id);
            if (advisor != null)
            {
                await _advisorRepository.DeleteAsync(advisor);
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _advisorRepository.ExistsAsync(id);
        }

        public Task AuthenticateAsync(object email, object password)
        {
            throw new NotImplementedException();
        }

        public Task AuthenticateAsync(object email, string? password)
        {
            throw new NotImplementedException();
        }

        public async Task<AdvisorDto?> AuthenticateAsync(string email, string password)
        {
            var advisor = await _advisorRepository.GetAdvisorByEmailAsync(email); // int'ten string'e dönüşüm yapılmasına gerek yok
            if (advisor == null || advisor.Password != password)
            {
                throw new UnauthorizedAccessException("Geçersiz danışman numarası veya şifre");
            }

            return _mapper.Map<AdvisorDto>(advisor);
        }

        public Task<List<StudentDto>> GetStudentsByAdvisorIdAsync(int advisorId)
        {
            throw new NotImplementedException();
        }
    }
}