using CHABA.DayCare.Data;
using CHABA.DayCare.Models.Core;
using CHABA.DayCare.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CHABA.DayCare.Repositories.Implementations
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly ApplicationDbContext _context;

        public ClassroomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Classroom>> GetAllAsync()
        {
            return await _context.Classrooms
                .Where(c => !c.IsDeleted)
                .OrderBy(c => c.MinimumAgeInMonths)
                .ToListAsync();
        }

        public async Task<Classroom?> GetByIdAsync(int id)
        {
            return await _context.Classrooms
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }
        public async Task AddAsync(Classroom classroom)
        {
            await _context.Classrooms.AddAsync(classroom);
            await _context.SaveChangesAsync();
        }
    }
}
