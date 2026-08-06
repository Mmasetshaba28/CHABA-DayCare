using CHABA.DayCare.Data;
using CHABA.DayCare.Models.Child;
using CHABA.DayCare.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CHABA.DayCare.Repositories.Implementations
{
    public class ChildRepository :IChildRepository
    {
        private readonly ApplicationDbContext _context;

        public ChildRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Child>> GetAllAsync()
        {
            return await _context.Children.Include(c => c.Classroom).Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task<Child?> GetByIdAsync(int id)
        {
            return await _context.Children.Include(c => c.Classroom).FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public async Task AddAsync(Child child)
        {
            await _context.Children.AddAsync(child);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Child child)
        {
            _context.Children.Update(child);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Children.AnyAsync(c => c.Id == id && !c.IsDeleted);
        }
    }
}
