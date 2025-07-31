using Microsoft.EntityFrameworkCore;
using MTS.Application.Interfaces;
using MTS.Domain.Entities;
using MTS.Persistence.Context;

namespace MTS.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MtsDbContext _context;

        public StudentRepository(MtsDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task AddAsync(Student entity)
        {
            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student entity)
        {
            _context.Students.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<Student>> GetAllStudentsWithDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetByStudentNumberAsync(int studentNumber)
        {
            throw new NotImplementedException();
        }

        public Task GetByStudentNumberAsync(string v)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        async Task<Student> IStudentRepository.GetByStudentNumberAsync(string studentNumber)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.StudentNumber == studentNumber);
        }
    }
}
