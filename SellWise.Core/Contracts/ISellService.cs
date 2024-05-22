using SellWise.Core.Models.ProductModel;
using SellWise.Core.Models.SaleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWise.Core.Contracts
{
    public interface ISellService
    {
        //Product functionality
        public Task<IEnumerable<ProductViewModel>> ViewAllProducts();

        public Task AddProductToSale(int productId);

        public Task RemoveProductFromSale(int productId);

        public Task IncreaseProductQuantity(int productId);

        public Task DecreaseProductQuantity(int productId);

        public Task<IEnumerable<SaleViewModel>> MySales(string userId);

        public Task CreateSale(string userId);

        public Task FinalizeSale(int id);

        public Task ContinueSale(int id);

        public Task SaleDetails(int id);
    }
}
