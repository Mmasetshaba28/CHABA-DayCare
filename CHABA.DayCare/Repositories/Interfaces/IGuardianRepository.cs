using CHABA.DayCare.Models.Guardian;

namespace CHABA.DayCare.Repositories.Interfaces
{
    public interface IGuardianRepository
    {
        Task<List<Guardian>> GetAllAsync();
        Task<Guardian?> GetByIdAsync(int id);
        Task AddAsync(Guardian guardian);
        Task UpdateAsync(Guardian guardian);
        Task DeleteAsync(Guardian guardian);
    }
}
