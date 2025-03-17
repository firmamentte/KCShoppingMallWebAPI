using System;
using System.Collections.Generic;

namespace KCShoppingMallWebAPI.Data.Entities;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string StockKeepingUnit { get; set; } = null!;

    public decimal Price { get; set; }

    public int AvailableQuantity { get; set; }

    public string ProductImage { get; set; } = null!;

    public bool Featured { get; set; }

    public bool OnSpecial { get; set; }
}
