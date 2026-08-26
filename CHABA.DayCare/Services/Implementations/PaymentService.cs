using CHABA.DayCare.Models.Finance;
using CHABA.DayCare.Repositories.Interfaces;
using CHABA.DayCare.Services.Interfaces;

namespace CHABA.DayCare.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }

        public async Task<Payment?> GetPaymentAsync(int id)
        {
            return await _paymentRepository.GetByIdAsync(id);
        }

        public async Task CreatePaymentAsync(Payment payment)
        {
            await _paymentRepository.AddAsync(payment);
        }
        public async Task UpdatePaymentAsync(Payment payment)
        {
            await _paymentRepository.UpdateAsync(payment);
        }
        public async Task DeletePaymentAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);

            if(payment != null)
            {
                await _paymentRepository.DeleteAsync(payment);
            }
        }
    }
}
