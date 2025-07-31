using MTS.Application.DTOs.Students;
using MTS.Domain.Entities;
using AutoMapper;
using MTS.Application.Interfaces;

namespace MTS.Application.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<List<StudentDto>>(students);
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) throw new KeyNotFoundException("Öğrenci bulunamadı");
            return _mapper.Map<StudentDto>(student);
        }

        public async Task CreateStudentAsync(CreateStudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentRepository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(UpdateStudentDto studentDto)
        {
            var student = await _studentRepository.GetByIdAsync(studentDto.Id);
            if (student == null) throw new KeyNotFoundException("Öğrenci bulunamadı");
            _mapper.Map(studentDto, student);
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) throw new KeyNotFoundException("Öğrenci bulunamadı");
            await _studentRepository.DeleteAsync(student);
        }

        // Authenticate metodunu, yalnızca gereken parametrelerle düzelttik

        public Task CreateStudent(CreateStudentDto studentDto)
        {
            throw new NotImplementedException();
        }

        public Task<StudentDto> AuthenticateAsync(int studentNumber, string password, object v)
        {
            throw new NotImplementedException();
        }

        public object Get_studentRepository()
        {
            throw new NotImplementedException();
        }

        public async Task<StudentDto> AuthenticateAsync(string studentNumber, string password)
        {
            var student = await _studentRepository.GetByStudentNumberAsync(studentNumber); // int'ten string'e dönüşüm yapılmasına gerek yok
            if (student == null || student.Password != password)
            {
                throw new UnauthorizedAccessException("Geçersiz öğrenci numarası veya şifre");
            }

            return _mapper.Map<StudentDto>(student);
        }
    }
}
