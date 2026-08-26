using CHABA.DayCare.Models.Finance;

namespace CHABA.DayCare.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAllPaymentsAsync();
        Task<Payment?> GetPaymentAsync(int id);
        Task CreatePaymentAsync(Payment payment);
        Task UpdatePaymentAsync(Payment payment);
        Task DeletePaymentAsync(int id);
    }
}
