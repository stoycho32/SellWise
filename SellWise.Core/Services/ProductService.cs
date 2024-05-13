using SellWise.Core.Contracts;
using SellWise.Infrastructure.Repository;

namespace SellWise.Core.Services
{
    public class ProductService : IProductService
    {
        public readonly IRepository repository;

        public ProductService(IRepository repository)
        {
            this.repository = repository;   
        }

        public Task ViewAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task GetProductDetails(int productId)
        {
            throw new NotImplementedException();
        }

        public Task AddProduct()
        {
            throw new NotImplementedException();
        }

        public Task RemoveProduct()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductManufacturer()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductQuantity(int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
