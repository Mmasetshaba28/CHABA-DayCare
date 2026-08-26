using CHABA.DayCare.Data;
using CHABA.DayCare.Models.Staff;
using CHABA.DayCare.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CHABA.DayCare.Repositories.Implementations
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;

        public StaffRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Staff>> GetAllAsync()
        {
            return await _context.Staff
                .Include(s => s.Classroom)
                .Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task<Staff?> GetByIdAsync(int id)
        {
            return await _context.Staff.Include(s =>s.Classroom).FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task AddAsync(Staff staff)
        {
            await _context.Staff.AddAsync(staff);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Staff staff)
        {
            _context.Staff.Update(staff);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Staff staff)
        {
            staff.IsDeleted = true;
            staff.ModifiedDate = DateTime.Now;

            _context.Staff.Update(staff);
            await _context.SaveChangesAsync();
        }
    }
}
