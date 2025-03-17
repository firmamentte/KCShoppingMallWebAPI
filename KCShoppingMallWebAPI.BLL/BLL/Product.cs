using KCShoppingMallWebAPI.BLL.DataContract;
using KCShoppingMallWebAPI.BLL.Interfaces;
using KCShoppingMallWebAPI.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace KCShoppingMallWebAPI.BLL.BLL
{
    public class Product(IConfiguration configuration) : IProduct
    {
        private readonly Data.DAL.Product product = new();

        public async Task<List<ProductResp>> GetProducts(bool? featured)
        {
            using KcshoppingMallContext dbContext = new(configuration);

            List<ProductResp> productResps = [];

            List<Data.Entities.Product> products = await product.GetProducts(dbContext, featured);

            if (products.Count == 0)
            {
                products = await CreateProducts();
            }

            foreach (var product in products)
            {
                productResps.Add(FillProductResp(product));
            }

            return productResps;
        }

        public async Task<List<Data.Entities.Product>> CreateProducts()
        {
            using KcshoppingMallContext dbContext = new(configuration);

            List<Data.Entities.Product> products = [];

            Random random = new();

            for (int i = 1; i <= 30; i++)
            {
                products.Add(new Data.Entities.Product
                {
                    AvailableQuantity = random.Next(1, 1000),
                    Featured = random.NextDouble() > 0.5,
                    OnSpecial = random.NextDouble() > 0.5,
                    Price = new decimal(random.Next(100, 1000)),
                    ProductImage = "ItemPicturePlaceHolder.jpg",
                    StockKeepingUnit = Guid.NewGuid().ToString(),
                    ProductName = $"Product Name {i}"
                });
            }

            await dbContext.AddRangeAsync(products);
            await dbContext.SaveChangesAsync();

            return products;
        }

        private ProductResp FillProductResp(Data.Entities.Product product)
        {
            return new ProductResp()
            {
                AvailableQuantity = product.AvailableQuantity,
                Featured = product.Featured,
                OnSpecial = product.OnSpecial,
                Price = product.Price,
                ProductImage = product.ProductImage,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                StockKeepingUnit = product.StockKeepingUnit
            };
        }
    }
}
