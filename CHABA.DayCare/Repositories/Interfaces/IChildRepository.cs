using CHABA.DayCare.Models.Child;

namespace CHABA.DayCare.Repositories.Interfaces
{
    public interface IChildRepository
    {
        Task<List<Child>> GetAllAsync();
        Task<Child?> GetByIdAsync(int id);
        Task AddAsync(Child child);
        Task UpdateAsync(Child child);
        Task<bool> ExistsAsync(int id);
        Task DeleteAsync(Child child);
    }
}
