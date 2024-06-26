﻿using Microsoft.EntityFrameworkCore;
using SellWise.Core.Contracts;
using SellWise.Core.Models.ProductModel;
using SellWise.Core.Models.SaleModel;
using SellWise.Infrastructure.Data.Models;
using SellWise.Infrastructure.Repository;
using System.Text;

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
                    TotalPrice = c.TotalPrice,
                    TotalPriceWithDiscount = c.TotalPriceWithDiscount
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
                throw new ArgumentException("Sale Cannot Be Created Due to an Invalid Shift");
            }

            Cashier? cashier = await this.repository.AllAsReadOnly<Cashier>().FirstOrDefaultAsync(c => c.Id == userId);

            if (cashier == null)
            {
                throw new ArgumentException("Sale Cannot Be Created Due to an Invalid Cashier");
            }

            Sale sale = new Sale()
            {
                CashierId = cashier.Id,
                ShiftId = currShift.Id,
            };

            await this.repository.AddAsync(sale);
            await this.repository.SaveChangesAsync();
        }

        public async Task<SaleViewModel> GetSale(int saleId, string userId)
        {
            SaleViewModel? sale = await this.repository.AllAsReadOnly<Sale>()
                .Where(c => c.Id == saleId && c.CashierId == userId)
                .Select(c => new SaleViewModel()
                {
                    Id = c.Id,
                    SaleStartDateTime = c.SaleStartDateTime,
                    IsFinalized = c.IsFinalized,
                    FinalizationDateTime = c.FinalizationDateTime,
                    IsDiscountAplied = c.IsDiscountAplied,
                    DiscountPercentage = c.DiscountPercentage,
                    TotalPrice = c.TotalPrice,
                    TotalPriceWithDiscount = c.TotalPriceWithDiscount,
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
                throw new ArgumentException("Sale Cannot Be Opened As It Was Not Found");
            }

            return sale;
        }

        public async Task DeleteSale(int saleId, string userId)
        {
            Sale? sale = await this.repository.All<Sale>()
                .AsSplitQuery()
                .Include(c => c.SaleProducts)
                .Where(c => c.Id == saleId).FirstOrDefaultAsync();

            if (sale == null)
            {
                throw new ArgumentException("Sale Cannot Be Deleted As It Was Not Found");
            }

            if (sale.IsFinalized == true || sale.FinalizationDateTime != null)
            {
                throw new InvalidOperationException("A Finalized Sale Cannot Be Deleted");
            }

            if (sale.CashierId != userId)
            {
                throw new InvalidOperationException("You Are Not Allowed To Delete This Sale");
            }

            if (sale.SaleProducts.Count() > 0)
            {
                sale.SaleProducts.Clear();
            }

            await this.repository.Remove(sale);
            await this.repository.SaveChangesAsync();
        }

        public async Task FinalizeSale(int saleId, string userId)
        {
            Sale? sale = await this.repository.All<Sale>()
                .AsSplitQuery()
                .Where(c => c.Id == saleId)
                .Include(c => c.SaleProducts)
                .ThenInclude(c => c.Product)
                .Include(c => c.Shift)
                .FirstOrDefaultAsync();

            if (sale == null)
            {
                throw new ArgumentException("The Sale Cannot Be Finalized As It Was Not Found");
            }

            if (sale.IsFinalized == true || sale.FinalizationDateTime != null)
            {
                throw new InvalidOperationException("The Sale Is Already Finalized");
            }

            if (sale.CashierId != userId)
            {
                throw new ArgumentException("You Are Not Allowed To Finalize This Sale");
            }

            foreach (var product in sale.SaleProducts)
            {
                product.Product.ProductQuantity -= product.ProductQuantity;
            }

            sale.IsFinalized = true;
            sale.FinalizationDateTime = DateTime.Now;

            if (sale.IsDiscountAplied == true)
            {
                sale.FinalPrice = sale.TotalPriceWithDiscount;
            }
            else
            {
                sale.FinalPrice = sale.TotalPrice;
            }

            sale.Shift.ShiftTotalAmount += decimal.Parse(sale.FinalPrice.ToString());
            //await this.repository.SaveChangesAsync();

            this.CreateBillReceipt(sale);
        }

        public Task SaleDetails(int saleId)
        {
            throw new NotImplementedException();
        }

        public async Task DecreaseProductQuantity(int saleId, int productId, string userId)
        {
            Sale? sale = await this.repository.All<Sale>()
                .AsSplitQuery()
                .Where(c => c.Id == saleId)
                .Include(c => c.SaleProducts)
                .ThenInclude(c => c.Product)
                .FirstOrDefaultAsync();

            if (sale == null)
            {
                throw new ArgumentException("The Product Quantity Cannot Be Decreased Because The Sale Is Not Found");
            }

            if (sale.CashierId != userId)
            {
                throw new InvalidOperationException("You Are Not Allowed To Decrease Product Quantity Of This Sale. You Are Not The Owner");
            }

            if (sale.IsFinalized == true || sale.FinalizationDateTime != null)
            {
                throw new InvalidOperationException("You Cannot Decrease Product Quantity In a Sale That Is Finalized");
            }

            if (!sale.SaleProducts.Any(c => c.ProductId == productId))
            {
                throw new ArgumentException("The Sale Does Not Contain The Product");
            }

            if (sale.IsDiscountAplied == true || sale.DiscountPercentage != null || sale.TotalPriceWithDiscount != null)
            {
                sale.IsDiscountAplied = false;
                sale.DiscountPercentage = null;
                sale.TotalPriceWithDiscount = null;
            }

            SaleProduct? saleProduct = sale.SaleProducts.FirstOrDefault(c => c.ProductId == productId);

            if (saleProduct != null)
            {
                if (saleProduct.ProductQuantity == 1)
                {
                    sale.SaleProducts.RemoveAll(c => c.ProductId == saleProduct.ProductId);
                }
                else
                {
                    saleProduct.ProductQuantity -= 1;
                }
            }

            sale.TotalPrice = this.CalculateTotalPrice(sale);
            await this.repository.SaveChangesAsync();
        }

        public async Task IncreaseProductQuantity(int saleId, int productId, string userId)
        {
            Sale? sale = await this.repository.All<Sale>()
                .AsSplitQuery()
                .Where(c => c.Id == saleId)
                .Include(c => c.SaleProducts)
                .ThenInclude(c => c.Product)
                .FirstOrDefaultAsync();

            if (sale == null)
            {
                throw new ArgumentException("The Product Quantity Cannot Be Increased Because The Sale Is Not Found");
            }

            if (sale.CashierId != userId)
            {
                throw new InvalidOperationException("You Are Not Allowed To Increase Product Quantity Of This Sale. You Are Not The Owner");
            }

            if (sale.IsFinalized == true || sale.FinalizationDateTime != null)
            {
                throw new InvalidOperationException("You Cannot Incrase Product Quantity In a Sale That Is Finalized");
            }

            if (!sale.SaleProducts.Any(c => c.ProductId == productId))
            {
                throw new ArgumentException("The Sale Does Not Contain The Product");
            }

            if (sale.IsDiscountAplied == true || sale.DiscountPercentage != null || sale.TotalPriceWithDiscount != null)
            {
                sale.IsDiscountAplied = false;
                sale.DiscountPercentage = null;
                sale.TotalPriceWithDiscount = null;
            }

            SaleProduct? saleProduct = sale.SaleProducts.FirstOrDefault(c => c.ProductId == productId);

            if (saleProduct != null)
            {
                saleProduct.ProductQuantity += 1;
            }

            sale.TotalPrice = this.CalculateTotalPrice(sale);
            await this.repository.SaveChangesAsync();
        }

        public async Task AddProductToSale(int saleId, int productId, string userId)
        {
            Product? productToAdd = await this.repository.All<Product>()
                .Where(c => c.Id == productId).FirstOrDefaultAsync();

            if (productToAdd == null)
            {
                throw new ArgumentException("You Cannot Add The Product. The Product Cannot Be Found");
            }

            Sale? sale = await this.repository.All<Sale>()
                .AsSplitQuery()
                .Include(c => c.SaleProducts)
                .ThenInclude(c => c.Product)
                .Where(c => c.Id == saleId).FirstOrDefaultAsync();

            if (sale == null)
            {
                throw new ArgumentException("You Cannot Add The Product. The Sale Cannot Be Found");
            }

            if (sale.CashierId != userId)
            {
                throw new InvalidOperationException("You Are Not Allowed To Add Products To This Sale. You Are Not The Owner");
            }

            if (sale.IsFinalized == true || sale.FinalizationDateTime != null)
            {
                throw new InvalidOperationException("You Cannot Add Product To a Finalized Sale");
            }

            if (sale.IsDiscountAplied == true || sale.DiscountPercentage != null || sale.TotalPriceWithDiscount != null)
            {
                sale.IsDiscountAplied = false;
                sale.DiscountPercentage = null;
                sale.TotalPriceWithDiscount = null;
            }

            if (sale.SaleProducts.Any(c => c.ProductId == productToAdd.Id))
            {
                SaleProduct? saleProduct = sale.SaleProducts.FirstOrDefault(c => c.ProductId == productId);

                if (saleProduct != null)
                {
                    saleProduct.ProductQuantity += 1;
                }
            }
            else
            {
                SaleProduct saleProduct = new SaleProduct()
                {
                    SaleId = sale.Id,
                    Sale = sale,
                    ProductId = productToAdd.Id,
                    Product = productToAdd
                };

                sale.SaleProducts.Add(saleProduct);
            }

            sale.TotalPrice = this.CalculateTotalPrice(sale);
            await this.repository.SaveChangesAsync();
        }

        public async Task RemoveProductFromSale(int saleId, int productId, string userId)
        {
            Sale? sale = await this.repository.All<Sale>()
                .AsSplitQuery()
                .Include(c => c.SaleProducts)
                .ThenInclude(c => c.Product)
                .Where(c => c.Id == saleId).FirstOrDefaultAsync();

            if (sale == null)
            {
                throw new ArgumentException("You Cannot Remove The Product. The Sale Cannot Be Found");
            }

            if (sale.CashierId != userId)
            {
                throw new InvalidOperationException("You Are Not Allowed To Remove Products From This Sale. You Are Not The Owner");
            }

            if (sale.IsFinalized == true || sale.FinalizationDateTime != null)
            {
                throw new InvalidOperationException("You Cannot Remove A Product From A Finalized Sale");
            }

            if (!sale.SaleProducts.Any(c => c.ProductId == productId))
            {
                throw new ArgumentException("The Product Cannot Be Deleted Because It Was Not Added To The Sale");
            }

            if (sale.IsDiscountAplied == true || sale.DiscountPercentage != null || sale.TotalPriceWithDiscount != null)
            {
                sale.IsDiscountAplied = false;
                sale.DiscountPercentage = null;
                sale.TotalPriceWithDiscount = null;
            }

            sale.SaleProducts.RemoveAll(c => c.ProductId == productId);

            sale.TotalPrice = this.CalculateTotalPrice(sale);
            await this.repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> ViewAllProducts(int saleId)
        {
            IEnumerable<ProductViewModel> products = await this.repository.AllAsReadOnly<Product>()
                .Where(c => c.IsDeleted == false)
                .Select(c => new ProductViewModel()
                {
                    Id = c.Id,
                    ProductName = c.ProductName,
                    ProductSellingPrice = c.ProductSellingPrice,
                    ProductQuantity = c.ProductQuantity,
                    SaleId = saleId
                })
                .ToListAsync();

            return products;
        }

        public async Task AddDiscount(int saleId, int discountPercentage, string userId)
        {
            Sale? sale = await this.repository.All<Sale>()
                .AsSplitQuery()
                .Where(c => c.Id == saleId)
                .FirstOrDefaultAsync();

            if (sale == null)
            {
                throw new ArgumentException("You Cannot Add Discount. The Sale Cannot Be Found");
            }

            if (sale.CashierId != userId)
            {
                throw new InvalidOperationException("You Are Not Allowed To Add Discount To This Sale. You Are Not The Owner");
            }

            if (sale.IsDiscountAplied == true)
            {
                throw new InvalidOperationException("You Cannot Add Discount To The Sale. It Was Already Added");
            }

            decimal discount = discountPercentage / 100m;

            sale.TotalPriceWithDiscount = sale.TotalPrice - (sale.TotalPrice * discount);
            sale.IsDiscountAplied = true;
            sale.DiscountPercentage = discountPercentage;
            await this.repository.SaveChangesAsync();
        }

        public async Task RemoveDiscountFromSale(int saleId, string userId)
        {
            Sale? sale = await this.repository.All<Sale>()
                .AsSplitQuery()
                .Where(c => c.Id == saleId)
                .FirstOrDefaultAsync();

            if (sale == null)
            {
                throw new ArgumentException("The Discount Of The Sale Cannot Be Removed As The Sale Cannot Be Found");
            }

            if (sale.IsDiscountAplied == false || sale.DiscountPercentage == null || sale.TotalPriceWithDiscount == null)
            {
                throw new InvalidOperationException("The Sale Does Not Have Any Discount");
            }

            if (sale.CashierId != userId)
            {
                throw new ArgumentException("You Do Not Have Permission to Remove Discount Of This Sale");
            }

            sale.IsDiscountAplied = false;
            sale.DiscountPercentage = null;
            sale.TotalPriceWithDiscount = null;

            await this.repository.SaveChangesAsync();
        }

        private decimal CalculateTotalPrice(Sale sale)
        {
            decimal totalPrice = sale.SaleProducts.Sum(c => c.ProductQuantity * c.Product.ProductSellingPrice);
            return totalPrice;
        }

        private void CreateBillReceipt(Sale sale)
        {
            string billName = "Bill - " + sale.Id;
            string bill = "C:\\Users\\karad\\OneDrive\\Desktop\\ASPNET Products\\SellWise\\SellWise\\SellWise.Core\\Bills\\" + billName;

            if (!File.Exists(bill))
            {
                using (FileStream fs = File.Create(bill))
                {
                    Byte[] billTitle = new UTF8Encoding().GetBytes($"Bill Number: {sale.Id}{Environment.NewLine}");
                    fs.Write(billTitle, 0, billTitle.Length);
                    Byte[] billStartDate = new UTF8Encoding().GetBytes($"Bill Start Date: {sale.SaleStartDateTime}{Environment.NewLine}");
                    fs.Write(billStartDate, 0, billStartDate.Length);
                    Byte[] billEndDate = new UTF8Encoding().GetBytes($"Bill End Date: {sale.FinalizationDateTime}{Environment.NewLine}");
                    fs.Write(billEndDate, 0, billEndDate.Length);

                    foreach (var product in sale.SaleProducts)
                    {
                        Byte[] billProduct = new UTF8Encoding()
                            .GetBytes($"Product: {product.Product.ProductName}" +
                            $" - Price: {product.Product.ProductSellingPrice}" +
                            $": Quantity: {product.ProductQuantity} - Total Price: {product.Product.ProductSellingPrice * product.ProductQuantity}{Environment.NewLine}");

                        fs.Write(billProduct, 0, billProduct.Length);
                    }

                    if (sale.IsDiscountAplied == true)
                    {
                        Byte[] billDiscount = new UTF8Encoding().GetBytes($"Discount: {sale.DiscountPercentage}%{Environment.NewLine}");
                        fs.Write(billDiscount, 0, billDiscount.Length);

                        Byte[] billTotalPrice = new UTF8Encoding().GetBytes($"Bill Total Price: {sale.TotalPrice}{Environment.NewLine}");
                        fs.Write(billTotalPrice, 0, billTotalPrice.Length);

                        Byte[] billTotalPriceWithDiscount = new UTF8Encoding().GetBytes($"Bill Total Price With Discount: {sale.FinalPrice}{Environment.NewLine}");
                        fs.Write(billTotalPriceWithDiscount, 0, billTotalPriceWithDiscount.Length);

                        Byte[] billFinalPrice = new UTF8Encoding().GetBytes($"Bill Final Price: {sale.FinalPrice}");
                        fs.Write(billFinalPrice, 0, billFinalPrice.Length);
                    }
                    else
                    {
                        Byte[] billDiscount = new UTF8Encoding().GetBytes($"Discount: N/A{Environment.NewLine}");
                        fs.Write(billDiscount, 0, billDiscount.Length);

                        Byte[] billTotalPrice = new UTF8Encoding().GetBytes($"Bill Total Price: {sale.FinalPrice}{Environment.NewLine}");
                        fs.Write(billTotalPrice, 0, billTotalPrice.Length);
                    }
                }
            }
        }
    }
}
