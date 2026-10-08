using CHABA.DayCare.Models.Child;

namespace CHABA.DayCare.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAsync();
        Task<List<Attendance>> GetByChildIdAsync(int childId);
        Task<Attendance?> GetByIdAsync(int id);
        Task<List<Attendance>> GetByDateAsync(DateTime date);
        Task<bool> ExistsForChildAndDateAsync(int childId, DateTime date);
        Task AddAsync(Attendance attendance);
        Task UpdateAsync(Attendance attendance);
        Task<bool> ExistsAsync(int id);
        
    }
}
