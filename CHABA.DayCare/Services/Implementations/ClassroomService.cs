using CHABA.DayCare.Models.Core;
using CHABA.DayCare.Repositories.Interfaces;
using CHABA.DayCare.Services.Interfaces;

namespace CHABA.DayCare.Services.Implementations
{
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;

        public ClassroomService(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public async Task<List<Classroom>> GetAllClassroomsAsync()
        {
            return await _classroomRepository.GetAllAsync();
        }
        public async Task<Classroom?> GetClassroomAsync(int id)
        {
            return await _classroomRepository.GetByIdAsync(id);
        }

        public async Task CreateClassroomAsync(Classroom classroom)
        {
            await _classroomRepository.AddAsync(classroom);
        }
    }
}
