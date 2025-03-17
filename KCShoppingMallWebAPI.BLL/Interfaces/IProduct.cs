using KCShoppingMallWebAPI.BLL.DataContract;

namespace KCShoppingMallWebAPI.BLL.Interfaces
{
    public interface IProduct
    {
        Task<List<ProductResp>> GetProducts(bool? featured);

        Task CreateProducts();
    }
}
