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

        public Task<SaleViewModel> GetSale(int saleId);

        public Task FinalizeSale(int saleId);

        public Task SaleDetails(int saleId);

        public Task DeleteSale(int saleId, string userId);
    }
}
