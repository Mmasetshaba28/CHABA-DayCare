using CHABA.DayCare.Data;
using CHABA.DayCare.Models.Finance;
using CHABA.DayCare.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CHABA.DayCare.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;
        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _context.Payments.Include(p => p.Child)
                .Where(p => !p.IsDeleted).OrderByDescending(p => p.PaymentDate).ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _context.Payments.Include(p => p.Child)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Payment payment)
        {
            payment.IsDeleted = true;
            payment.ModifiedDate = DateTime.Now;

            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }
    }
}
