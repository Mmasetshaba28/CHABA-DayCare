using CHABA.DayCare.Models.Staff;

namespace CHABA.DayCare.Repositories.Interfaces
{
    public interface IStaffRepository
    {
        Task<List<Staff>> GetAllAsync();
        Task<Staff?> GetByIdAsync(int id);
        Task AddAsync(Staff staff); 
        Task UpdateAsync(Staff staff);
        Task DeleteAsync(Staff staff);
    }
}
