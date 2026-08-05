using CHABA.DayCare.Models.Core;

namespace CHABA.DayCare.Services.Interfaces
{
    public interface IClassroomService
    {
        Task<List<Classroom>> GetAllClassroomsAsync();

        Task<Classroom?> GetClassroomAsync(int id);

        Task CreateClassroomAsync(Classroom classroom);
    }
}
