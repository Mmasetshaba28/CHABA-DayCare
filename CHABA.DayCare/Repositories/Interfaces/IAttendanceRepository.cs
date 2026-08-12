using CHABA.DayCare.Models.Child;

namespace CHABA.DayCare.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAsync();
        Task<List<Attendance>> GetByChildIdAsync(int childId);
        Task<Attendance?> GetByIdAsync(int id);
        Task AddAsync(Attendance attendance);
        Task UpdateAsync(Attendance attendance);
        Task<bool> ExistsAsync(int id);
    }
}
