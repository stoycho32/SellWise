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

        //Sale functionality
        public Task<IEnumerable<SaleViewModel>> MySales(string userId);

        public Task CreateSale();

        public Task CancelSale(int id);

        public Task FinalizeSale(int id);

        public Task OpenSale(int id);
    }
}
