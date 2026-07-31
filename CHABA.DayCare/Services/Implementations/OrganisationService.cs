using CHABA.DayCare.Models.Core;
using CHABA.DayCare.Repositories.Interfaces;
using CHABA.DayCare.Services.Interfaces;

namespace CHABA.DayCare.Services.Implementations
{
    public class OrganisationService: IOrganisationService
    {
        private readonly IOrganisationRepository _organisationRepository;
        public OrganisationService(IOrganisationRepository organisationRepository)
        {
            _organisationRepository = organisationRepository;   
        }

        public async Task<Organisation?> GetOrganisationAsync()
        {
            return await _organisationRepository.GetAsync();
        }

        public async Task CreateOrganisationAsync(Organisation organisation)
        {
            await _organisationRepository.AddAsync(organisation);
        }
        public async Task UpdateOrganisationAsync(Organisation organisation)
        {
            await _organisationRepository.UpdateAsync(organisation);
        }
        public async Task<bool> OrganisationExistsAsync()
        {
            return await _organisationRepository.ExistsAsync();
        }
    }
}
