using CHABA.DayCare.Models.Child;

namespace CHABA.DayCare.Services.Interfaces
{
    public interface IChildService
    {
        Task<List<Child>> GetAllChildrenAsync();
        Task<Child?> GetChildAsync(int id);
        Task CreateChildAsync(Child child);
        Task UpdateChildAsync(Child child);
        Task DeleteChildAsync(int id);

    }
}
