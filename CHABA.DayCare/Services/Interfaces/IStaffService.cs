using CHABA.DayCare.Models.Staff;

namespace CHABA.DayCare.Services.Interfaces
{
    public interface IStaffService
    {
        Task<List<Staff>> GetAllStaffAsync();
        Task<Staff?> GetStaffAsync(int id);
        Task CreateStaffAsync(Staff staff);
        Task UpdateStaffAsync(Staff staff);
        Task DeleteStaffAsync(int id);
    }
}
