using KCShoppingMallWebAPI.BLL.DataContract;

namespace KCShoppingMallWebAPI.Controllers.Helpers
{
    public class Product
    {
        internal async Task GetProductImagesBase64String(IWebHostEnvironment webHostEnvironment, List<ProductResp> productResps)
        {
            foreach (var productResp in productResps)
            {
                productResp.ProductImageBase64String = await GetProductImageBase64String(webHostEnvironment, productResp.ProductImage);
            }
        }

        private async Task<string> GetProductImageBase64String(IWebHostEnvironment webHostEnvironment, string productImage)
        {
            if (string.IsNullOrWhiteSpace(productImage))
            {
                return string.Empty;
            }

            string path = Path.Combine(webHostEnvironment.ContentRootPath, "Content", "ProductPictures", productImage);

            if (!File.Exists(path))
            {
                return string.Empty;
            }

            return $"data:{GetExtension(productImage)};base64,{Convert.ToBase64String(await File.ReadAllBytesAsync(path))}";
        }

        private string GetExtension(string productImage)
        {
            var extension = Path.GetExtension(productImage);
            return extension.Substring(extension.IndexOf('.') + 1);
        }
    }
}
