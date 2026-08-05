using CHABA.DayCare.Models.Child;
using CHABA.DayCare.Repositories.Interfaces;
using CHABA.DayCare.Services.Interfaces;

namespace CHABA.DayCare.Services.Implementations
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _childRepository;

        public ChildService(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<List<Child>> GetAllChildrenAsync()
        {
            return await _childRepository.GetAllAsync();
        }

        public async Task<Child?> GetChildAsync(int id)
        {
            return await _childRepository.GetByIdAsync(id);
        }

        public async Task CreateChildAsync(Child child)
        {
            await _childRepository.AddAsync(child);
        }

        public async Task UpdateChildAsync(Child child)
        {
            await _childRepository.UpdateAsync(child);
        }
    }
}
