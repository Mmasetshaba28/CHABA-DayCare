using CHABA.DayCare.Models.Guardian;

namespace CHABA.DayCare.Services.Interfaces
{
    public interface IGuardianService
    {
        Task<List<Guardian>> GetAllGuardiansAsync();
        Task<Guardian?> GetGuardianAsync(int id);
        Task CreateGuardianAsync(Guardian guardian);
        Task UpdateGuardianAsync(Guardian guardian);
        Task DeleteGuardianAsync(int id);
    }
}
