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
                    IsFinalized = c.IsFinalized,
                    FinalizationDateTime = c.FinalizationDateTime,
                    IsDiscountAplied = c.IsDiscountAplied,
                    DiscountPercentage = c.DiscountPercentage,
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

        public async Task<SaleViewModel> GetSale(int id)
        {
            SaleViewModel? sale = await this.repository.AllAsReadOnly<Sale>()
                .Where(c => c.Id == id)
                .Select(c => new SaleViewModel()
                {
                    Id = c.Id,
                    SaleStartDateTime = c.SaleStartDateTime,
                    IsFinalized = c.IsFinalized,
                    FinalizationDateTime = c.FinalizationDateTime,
                    IsDiscountAplied = c.IsDiscountAplied,
                    DiscountPercentage = c.DiscountPercentage,
                    TotalPrice = c.TotalPrice,
                    SaleProducts = c.SaleProducts.Select(c => new ProductViewModel()
                    {
                        Id = c.ProductId,
                        ProductName = c.Product.ProductName,
                        ProductQuantity = c.ProductQuantity,
                        ProductSellingPrice = c.Product.ProductSellingPrice
                    }).ToList()

                }).FirstOrDefaultAsync();

            if (sale == null)
            {
                throw new ArgumentException("The Sale Cannot Be Opened. It Is Invalid");
            }

            return sale;
        }

        public async Task DeleteSale(int id, string userId)
        {
            Sale? sale = await this.repository.AllAsReadOnly<Sale>()
                .Where(c => c.Id == id).FirstOrDefaultAsync();

            if (sale == null)
            {
                throw new ArgumentException("Sale Cannot Be Deleted Due To Invalid Data");
            }

            if (sale.IsFinalized == true || sale.FinalizationDateTime != null)
            {
                throw new InvalidOperationException("A Finalized Sale Cannot Be Deleted");
            }

            if (sale.CashierId != userId)
            {
                throw new InvalidOperationException("You Are Not Allowed To Delete This Sale");
            }

            await this.repository.Remove(sale);
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
