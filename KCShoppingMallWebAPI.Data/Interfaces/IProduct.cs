using KCShoppingMallWebAPI.Data.Entities;

namespace KCShoppingMallWebAPI.Data.Interfaces
{
    public interface IProduct
    {
        Task<List<Product>> GetProducts(KcshoppingMallContext dbContext, bool? featured);
    }
}
