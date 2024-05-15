using SellWise.Core.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWise.Core.Contracts
{
    public interface ISellService
    {
        public Task<IEnumerable<ProductViewModel>> ViewAllProducts();

        public Task AddProductToSale(int productId);

        public Task RemoveProductFromSale(int productId);

        public Task IncreaseProductQuantity(int productId);

        public Task DecreaseProductQuantity(int productId);

        public Task CreateSale();

        public Task CancelSale();

        public Task FinalizeSale();
    }
}
