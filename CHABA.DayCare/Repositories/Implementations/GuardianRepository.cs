using CHABA.DayCare.Data;
using CHABA.DayCare.Models.Guardian;
using CHABA.DayCare.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CHABA.DayCare.Repositories.Implementations
{
    public class GuardianRepository : IGuardianRepository
    {
        private readonly ApplicationDbContext _context;

        public GuardianRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Guardian>> GetAllAsync()
        {
            return await _context.Guardians.Include(g => g.Child).Where(g => !g.IsDeleted).ToListAsync();
        }

        public async Task<Guardian?> GetByIdAsync(int id)
        {
            return await _context.Guardians.Include(g => g.Child).FirstOrDefaultAsync(g => g.Id == id && !g.IsDeleted);
        }

        public async Task AddAsync(Guardian guardian)
        {
            await _context.Guardians.AddAsync(guardian);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guardian guardian)
        {
            _context.Guardians.Update(guardian);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guardian guardian)
        {
            guardian.IsDeleted = true;
            guardian.ModifiedDate = DateTime.Now;
            _context.Guardians.Update(guardian);
            await _context.SaveChangesAsync();
        }
    }
}
