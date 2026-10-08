using CHABA.DayCare.Models.Finance;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CHABA.DayCare.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task<List<Payment>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
        Task<Payment?> GetByIdAsync(int id);
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(Payment payment);
    }
}
