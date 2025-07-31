using Microsoft.EntityFrameworkCore;
using MTS.Application.Interfaces;
using MTS.Domain.Entities;
using MTS.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.Persistence.Repositories
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly MtsDbContext _context;

        public AdvisorRepository(MtsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Advisor entity)
        {
            await _context.Advisors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var advisor = await _context.Advisors.FindAsync(id);
            if (advisor != null)
            {
                _context.Advisors.Remove(advisor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Advisor entity)
        {
            _context.Advisors.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Advisors.AnyAsync(a => a.Id == id);
        }

        public async Task<Advisor> GetAdvisorByEmailAsync(string email)
        {
            return await _context.Advisors.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<Advisor> GetAdvisorByIdWithStudentsAsync(int id)
        {
            return await _context.Advisors
                .Include(a => a.Students) // Assuming there's a navigation property
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Advisor>> GetAdvisorsWithStudentsAsync()
        {
            return await _context.Advisors
                .Include(a => a.Students) // Assuming there's a navigation property
                .ToListAsync();
        }

        public async Task<IEnumerable<Advisor>> GetAllAsync()
        {
            return await _context.Advisors
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Advisor> GetByIdAsync(int id)
        {
            return await _context.Advisors.FindAsync(id);
        }

        public Task<Student> GetByStudentNumberAsync(int studentNumber)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Advisor entity)
        {
            _context.Advisors.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}