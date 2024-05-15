using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using SellWise.Core.Contracts;
using SellWise.Core.Models.ProductModel;
using SellWise.Infrastructure.Data.Models;
using SellWise.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWise.Core.Services
{
    public class SellService : ISellService
    {
        private readonly IRepository repository;

        public SellService(IRepository repository)
        {
            this.repository = repository;
        }

        public Task AddProductToSale(int productId)
        {
            throw new NotImplementedException();
        }

        public Task CancelSale()
        {
            throw new NotImplementedException();
        }

        public Task CreateSale()
        {
            throw new NotImplementedException();
        }

        public Task DecreaseProductQuantity(int productId)
        {
            throw new NotImplementedException();
        }

        public Task FinalizeSale()
        {
            throw new NotImplementedException();
        }

        public Task IncreaseProductQuantity(int productId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductFromSale(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductViewModel>> ViewAllProducts()
        {
            var products = await this.repository.AllAsReadOnly<Product>()
                .AsSplitQuery()
                .Where(c => c.IsDeleted == false)
                .Select(c => new ProductViewModel()
                {
                    Id = c.Id,
                    ProductName = c.ProductName,
                    ProductQuantity = c.ProductQuantity,
                    ProductSellingPrice = c.ProductSellingPrice,
                    ManufacturerName = c.Manufacturer.ManufacturerName
                }).ToListAsync();

            return products;
        }
    }
}
