using CHABA.DayCare.Models.Core;

namespace CHABA.DayCare.Services.Interfaces
{
    public interface IOrganisationService
    {
        Task<Organisation?> GetOrganisationAsync();
        Task CreateOrganisationAsync(Organisation organisation);
        Task UpdateOrganisationAsync(Organisation organisation);
        Task<bool> OrganisationExistsAsync();
    }

}
