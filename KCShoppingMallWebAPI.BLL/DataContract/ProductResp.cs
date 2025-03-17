namespace KCShoppingMallWebAPI.BLL.DataContract
{
    public class ProductResp
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string StockKeepingUnit { get; set; } = null!;

        public decimal Price { get; set; }

        public int AvailableQuantity { get; set; }

        public string ProductImage { get; set; } = null!;

        public string ProductImageBase64String { get; set; } = null!;

        public bool Featured { get; set; }

        public bool OnSpecial { get; set; }
    }
}
