using CHABA.DayCare.Models.Child;
using CHABA.DayCare.Repositories.Interfaces;
using CHABA.DayCare.Services.Interfaces;

namespace CHABA.DayCare.Services.Implementations
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<List<Attendance>> GetAllAttendanceAsync()
        {
            return await _attendanceRepository.GetAllAsync();
        }

        public async Task<List<Attendance>> GetAttendanceByChildAsync(int childId)
        {
            return await _attendanceRepository.GetByChildIdAsync(childId);
        }

        public async Task<Attendance?> GetAttendanceAsync(int id)
        {
            return await _attendanceRepository.GetByIdAsync(id);
        }

        public async Task CreateAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.AddAsync(attendance);
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.UpdateAsync(attendance);
        }

        public async Task<bool> AttendendanceExistsAsync(int id)
        {
            return await _attendanceRepository.ExistsAsync(id);
        }
    }
}
