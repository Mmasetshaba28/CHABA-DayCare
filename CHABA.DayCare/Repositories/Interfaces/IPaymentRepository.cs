using CHABA.DayCare.Models.Finance;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CHABA.DayCare.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(Payment payment);
    }
}
