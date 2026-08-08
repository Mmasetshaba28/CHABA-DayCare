using CHABA.DayCare.Models.Guardian;
using CHABA.DayCare.Repositories.Interfaces;
using CHABA.DayCare.Services.Interfaces;

namespace CHABA.DayCare.Services.Implementations
{
    public class GuardianService : IGuardianService
    {
        private readonly IGuardianRepository _guardianRepository;
        public GuardianService(IGuardianRepository guardianRepository)
        {
            _guardianRepository = guardianRepository;
        }

        public async Task<List<Guardian>> GetAllGuardiansAsync()
        {
            return await _guardianRepository.GetAllAsync();
        }
        public async Task<Guardian?> GetGuardianAsync(int id)
        {
            return await _guardianRepository.GetByIdAsync(id);
        }

        public async Task CreateGuardianAsync(Guardian guardian)
        {
            await _guardianRepository.AddAsync(guardian);
        }

        public async Task UpdateGuardianAsync(Guardian guardian)
        {
            await _guardianRepository.UpdateAsync(guardian);
        }

        public async Task DeleteGuardianAsync(int id)
        {
            var guardian = await _guardianRepository.GetByIdAsync(id);
            if (guardian == null)
                return;
            await _guardianRepository.DeleteAsync(guardian);
        }
    }
}
