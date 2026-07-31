using CHABA.DayCare.Models.Core;

namespace CHABA.DayCare.Repositories.Interfaces
{
    public interface IOrganisationRepository
    {
        Task<Organisation?> GetAsync();
        Task AddAsync(Organisation organisation);
        Task UpdateAsync(Organisation organisation);
        Task<bool> ExistsAsync();
    }
}
