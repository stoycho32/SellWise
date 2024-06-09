using SellWise.Core.Models.ProductModel;
using SellWise.Core.Models.SaleModel;

namespace SellWise.Core.Contracts
{
    public interface ISaleService
    {
        public Task<IEnumerable<ProductViewModel>> ViewAllProducts(int saleId);

        public Task AddProductToSale(int saleId, int productId, string userId);

        public Task RemoveProductFromSale(int saleId, int productId, string userId);

        public Task IncreaseProductQuantity(int saleId, int productId, string userId);

        public Task DecreaseProductQuantity(int saleId, int productId, string userId);

        public Task<IEnumerable<SaleViewModel>> MySales(string userId);

        public Task CreateSale(string userId);

        public Task<SaleViewModel> GetSale(int saleId, string userId);

        public Task FinalizeSale(int saleId, string userId);

        public Task SaleDetails(int saleId);

        public Task DeleteSale(int saleId, string userId);

        public Task AddDiscount(int saleId, int discountPercentage, string userId);
    }
}
