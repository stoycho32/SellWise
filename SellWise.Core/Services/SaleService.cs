using Microsoft.EntityFrameworkCore;
using SellWise.Core.Contracts;
using SellWise.Core.Models.ProductModel;
using SellWise.Core.Models.SaleModel;
using SellWise.Infrastructure.Data.Models;
using SellWise.Infrastructure.Repository;

namespace SellWise.Core.Services
{
    public class SaleService : ISaleService
    {
        private readonly IRepository repository;

        public SaleService(IRepository repository)
        {
            this.repository = repository;
        }


        public async Task<IEnumerable<SaleViewModel>> MySales(string userId)
        {
            IEnumerable<SaleViewModel> sales = await this.repository.AllAsReadOnly<Sale>()
                .Where(c => c.CashierId == userId)
                .OrderByDescending(c => c.IsFinalized == false)
                .ThenByDescending(c => c.SaleStartDateTime)
                .Select(c => new SaleViewModel()
                {
                    Id = c.Id,
                    SaleStartDateTime = c.SaleStartDateTime,
                    FinalizationDateTime = c.FinalizationDateTime,
                    TotalPrice = c.TotalPrice
                })
                .ToListAsync();

            return sales;
        }

        public async Task CreateSale(string userId)
        {
            Shift? currShift = await this.repository.AllAsReadOnly<Shift>()
                .Where(c => c.IsFinalized == false && c.CashierId == userId).FirstOrDefaultAsync();

            if (currShift == null)
            {
                throw new ArgumentException("Sale Cannot Be Created Due to Invalid Shift");
            }

            Cashier? cashier = await this.repository.AllAsReadOnly<Cashier>().FirstOrDefaultAsync(c => c.Id == userId);

            if (cashier == null)
            {
                throw new ArgumentException("Sale Cannot Be Created Due to Invalid Cashier");
            }

            Sale sale = new Sale() 
            {
                CashierId = cashier.Id,
                ShiftId = currShift.Id
            };

            await this.repository.AddAsync(sale);
            await this.repository.SaveChangesAsync();
        }

        public Task<SaleViewModel> GetSale(int id)
        {
            throw new NotImplementedException();
        }

        public Task CancelSale(int id)
        {
            throw new NotImplementedException();
        }

        public Task FinalizeSale(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaleDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task DecreaseProductQuantity(int productId)
        {
            throw new NotImplementedException();
        }

        public Task IncreaseProductQuantity(int productId)
        {
            throw new NotImplementedException();
        }

        public Task AddProductToSale(int productId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductFromSale(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductViewModel>> ViewAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
