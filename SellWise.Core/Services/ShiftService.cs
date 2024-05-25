using Microsoft.EntityFrameworkCore;
using SellWise.Core.Contracts;
using SellWise.Infrastructure.Data.Models;
using SellWise.Infrastructure.Repository;

namespace SellWise.Core.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IRepository repository;

        public ShiftService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task StartShift(string userId)
        {
            Cashier? cashier = await this.repository.AllAsReadOnly<Cashier>()
                .Where(c => c.Id == userId).FirstOrDefaultAsync();

            if (cashier == null)
            {
                throw new ArgumentException("Invalid Profile");
            }

            Shift? shift = await this.repository.AllAsReadOnly<Shift>()
                .Where(c => c.CashierId == userId && c.IsFinalized == false).FirstOrDefaultAsync();

            if (shift == null)
            {
                Shift newShift = new Shift()
                {
                    CashierId = cashier.Id
                };

                await this.repository.AddAsync<Shift>(newShift);
                await this.repository.SaveChangesAsync();
            }
        }
    }
}
