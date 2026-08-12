using CHABA.DayCare.Models.Child;

namespace CHABA.DayCare.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<List<Attendance>> GetAllAttendanceAsync();
        Task<List<Attendance>> GetAttendanceByChildAsync(int childId);
        Task<Attendance?> GetAttendanceAsync(int id);
        Task CreateAttendanceAsync(Attendance attendance);
        Task UpdateAttendanceAsync(Attendance attendance);
        Task<bool> AttendendanceExistsAsync(int id);
    }
}
