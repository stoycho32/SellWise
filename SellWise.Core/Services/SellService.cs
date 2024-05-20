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
                .OrderByDescending(c => c.SaleStartDateTime)
                .ToListAsync();

            return sales;
        }

        public Task CreateSale()
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

        public Task ContinueSale(int id)
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

        public async Task<IEnumerable<ProductViewModel>> ViewAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
