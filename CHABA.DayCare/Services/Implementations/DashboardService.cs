using CHABA.DayCare.Repositories.Interfaces;
using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Dashboard;

namespace CHABA.DayCare.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IOrganisationRepository _organisationRepository;
        public DashboardService(IOrganisationRepository organisationRepository)
        {
            _organisationRepository = organisationRepository;
        }

        public async Task<DashboardViewModel> GetDashboardAsync()
        {
            var organisation = await _organisationRepository.GetAsync();

            return new DashboardViewModel
            {
                OrganisationName = organisation?.Name ?? "",
                Motto = organisation?.Motto,
                ClassroomCount = 4, // Temporary
                ChildrenCount = 0,
                ParentCount = 0,
                TeacherCount = 3 // Temporary
            };
        }
    }
}
