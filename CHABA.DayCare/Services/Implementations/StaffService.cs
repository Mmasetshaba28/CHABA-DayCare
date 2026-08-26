using CHABA.DayCare.Models.Staff;
using CHABA.DayCare.Repositories.Interfaces;
using CHABA.DayCare.Services.Interfaces;

namespace CHABA.DayCare.Services.Implementations
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<List<Staff>> GetAllStaffAsync()
        {
            return await _staffRepository.GetAllAsync();
        }

        public async Task<Staff?> GetStaffAsync(int id)
        {
            return await _staffRepository.GetByIdAsync(id);
        }

        public async Task CreateStaffAsync(Staff staff)
        {
            await _staffRepository.AddAsync(staff);
        }

        public async Task UpdateStaffAsync(Staff staff)
        {
            await _staffRepository.UpdateAsync(staff);
        }

        public async Task DeleteStaffAsync(int id)
        {
            var staff = await _staffRepository.GetByIdAsync(id);

            if (staff != null)
            {
                await _staffRepository.DeleteAsync(staff);
            }
        }
    }
}
