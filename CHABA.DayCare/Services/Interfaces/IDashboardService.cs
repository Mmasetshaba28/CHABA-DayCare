using CHABA.DayCare.ViewModels.Dashboard;

namespace CHABA.DayCare.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetDashboardAsync();
    }
}
