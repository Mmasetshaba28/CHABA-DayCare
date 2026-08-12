using CHABA.DayCare.Data;
using CHABA.DayCare.Models.Child;
using CHABA.DayCare.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CHABA.DayCare.Repositories.Implementations
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Attendance>> GetAllAsync()
        {
            return await _context.Attendances
                .Include(a => a.Child)
                .Where(a => !a.IsDeleted)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

        public async Task<List<Attendance>> GetByChildIdAsync(int childId)
        {
            return await _context.Attendances
                .Include(a => a.Child)
                .Where(a => a.ChildId == childId && !a.IsDeleted)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            return await _context.Attendances
                .Include(a => a.Child)
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }

        public async Task AddAsync(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Attendances
                .AnyAsync(a => a.Id == id && !a.IsDeleted);
        }
    }
}
