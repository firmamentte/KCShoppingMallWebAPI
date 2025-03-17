using KCShoppingMallWebAPI.Data.Entities;
using KCShoppingMallWebAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KCShoppingMallWebAPI.Data.DAL
{
    public class Product : IProduct
    {
        public async Task<List<Entities.Product>> GetProducts(KcshoppingMallContext dbContext, bool? featured)
        {
            var queryable = from product in dbContext.Products
                            select new
                            {
                                product
                            };

            if (featured is not null)
            {
                queryable = queryable.Where(x => x.product.Featured == featured);
            }

            return await queryable.Select(x => x.product).
                OrderBy(x => x.ProductName).
                ToListAsync();
        }
    }
}
