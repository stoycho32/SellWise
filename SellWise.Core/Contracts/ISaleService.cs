using SellWise.Core.Models.ProductModel;
using SellWise.Core.Models.SaleModel;

namespace SellWise.Core.Contracts
{
    public interface ISaleService
    {
        public Task<IEnumerable<ProductViewModel>> ViewAllProducts();

        public Task AddProductToSale(int productId);

        public Task RemoveProductFromSale(int productId);

        public Task IncreaseProductQuantity(int productId);

        public Task DecreaseProductQuantity(int productId);

        public Task<IEnumerable<SaleViewModel>> MySales(string userId);

        public Task CreateSale(string userId);

        public Task<SaleViewModel> GetSale(int id);

        public Task FinalizeSale(int id);

        public Task SaleDetails(int id);

        public Task DeleteSale(int id, string userId);
    }
}
