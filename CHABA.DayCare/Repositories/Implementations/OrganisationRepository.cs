using CHABA.DayCare.Data;
using CHABA.DayCare.Models.Core;
using CHABA.DayCare.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CHABA.DayCare.Repositories.Implementations
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private readonly ApplicationDbContext _context;

        public OrganisationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Organisation?> GetAsync()
        {
            return await _context.Organisations.FirstOrDefaultAsync(o => !o.IsDeleted);
        }
        public async Task AddAsync(Organisation organisation)
        {
            await _context.Organisations.AddAsync(organisation);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Organisation organisation)
        {
            _context.Organisations.Update(organisation);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync()
        {
            return await _context.Organisations.AnyAsync(o =>!o.IsDeleted);
        }

    }
}
