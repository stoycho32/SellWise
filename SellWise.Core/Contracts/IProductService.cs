using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWise.Core.Contracts
{
    public interface IProductService
    {
        public Task ViewAllProducts();

        public Task GetProductDetails(int productId);

        public Task AddProduct();

        public Task RemoveProduct();

        public Task UpdateProductQuantity(int quantity);

        public Task UpdateProductPrice(decimal price);

        public Task UpdateProductManufacturer();
    }
}
