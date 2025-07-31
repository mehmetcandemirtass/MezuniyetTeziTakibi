using Microsoft.EntityFrameworkCore;
using MTS.Domain.Entities;
using MTS.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.Persistence.Repositories
{
    public class ThesisRepository : IThesisRepository
    {
        private readonly MtsDbContext _context;

        public ThesisRepository(MtsDbContext context)
        {
            _context = context;
        }

        // IGenericRepository implementasyonları
        public async Task<IEnumerable<ThesisTopic>> GetAllAsync()
        {
            return await _context.ThesisTopics.ToListAsync();
        }

        public async Task<ThesisTopic> GetByIdAsync(int id)
        {
            return await _context.ThesisTopics.FindAsync(id);
        }

        public async Task AddAsync(ThesisTopic entity)
        {
            await _context.ThesisTopics.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ThesisTopic entity)
        {
            _context.ThesisTopics.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var thesis = await _context.ThesisTopics.FindAsync(id);
            if (thesis != null)
            {
                _context.ThesisTopics.Remove(thesis);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.ThesisTopics.AnyAsync(t => t.Id == id);
        }

        // Özel metod implementasyonları
        public async Task<List<ThesisTopic>> GetThesesWithAdvisorsAndStudentsAsync()
        {
            return await _context.ThesisTopics
                .Include(t => t.Advisor)
                .Include(t => t.Student)
                .ToListAsync();
        }

        public async Task<ThesisTopic> GetThesisByIdWithDetailsAsync(int id)
        {
            return await _context.ThesisTopics
                .Include(t => t.Advisor)
                .Include(t => t.Student)
                .Include(t => t.JuryMembers)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateStatusAsync(int thesisId, string status)
        {
            var thesis = await _context.ThesisTopics.FindAsync(thesisId);
            if (thesis != null)
            {
                thesis.Status = status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AssignJuryMembersAsync(int thesisId, IEnumerable<int> juryMemberIds)
        {
            var thesis = await _context.ThesisTopics
                .Include(t => t.JuryMembers)
                .FirstOrDefaultAsync(t => t.Id == thesisId);

            if (thesis != null)
            {
                // Önce mevcut jüri üyelerini temizle
                thesis.JuryMembers.Clear();

       

                await _context.SaveChangesAsync();
            }
        }

        public Task DeleteAsync(ThesisTopic entity)
        {
            throw new NotImplementedException();
        }

        public Task<ThesisTopic> GetByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ThesisTopic> GetByIdWithJuryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetByStudentNumberAsync(int studentNumber)
        {
            throw new NotImplementedException();
        }
    }
}