using Microsoft.EntityFrameworkCore;
using SellWise.Core.Contracts;
using SellWise.Core.Models.ProductModel;
using SellWise.Core.Models.SaleModel;
using SellWise.Infrastructure.Data.Models;
using SellWise.Infrastructure.Repository;

namespace SellWise.Core.Services
{
    public class SellService : ISellService
    {
        private readonly IRepository repository;

        public SellService(IRepository repository)
        {
            this.repository = repository;
        }


        public async Task<IEnumerable<SaleViewModel>> MySales(string userId)
        {
            IEnumerable<SaleViewModel> sales = await this.repository.AllAsReadOnly<Sale>()
                .AsSplitQuery()
                .Where(c => c.CashierId == userId)
                .Select(c => new SaleViewModel()
                {
                    Id = c.Id,
                    SaleStartDateTime = c.SaleStartDateTime,
                    IsFinalized = c.IsFinalized,
                    FinalizationDateTime = c.FinalizationDateTime,
                    TotalPrice = c.TotalPrice
                })
                .OrderBy(c => c.IsFinalized == false)
                .OrderByDescending(c => c.SaleStartDateTime)
                .ToListAsync();

            return sales;
        }

        public async Task CreateSale(string userId)
        {
            Sale sale = new Sale();

            Cashier cashier = await this.repository.AllAsReadOnly<Cashier>().FirstOrDefaultAsync(c => c.Id == userId);

            if (cashier == null)
            {
                throw new ArgumentException("Invalid Cashier Details");
            }



            await this.repository.AddAsync(sale);
            await this.repository.SaveChangesAsync();
        }

        public Task CancelSale(int id)
        {
            throw new NotImplementedException();
        }

        public Task FinalizeSale(int id)
        {
            throw new NotImplementedException();
        }

        public Task ContinueSale(int id)
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
