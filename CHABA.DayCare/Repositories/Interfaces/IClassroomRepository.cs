using CHABA.DayCare.Models.Core;

namespace CHABA.DayCare.Repositories.Interfaces
{
    public interface IClassroomRepository
    {
        Task<List<Classroom>> GetAllAsync();

        Task<Classroom?> GetByIdAsync(int id);

        Task AddAsync(Classroom classroom);
    }
}
