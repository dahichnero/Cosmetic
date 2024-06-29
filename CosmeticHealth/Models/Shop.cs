using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class Shop
{
    public int ShopId { get; set; }

    public string NameShop { get; set; } = null!;

    public string UrAddress { get; set; } = null!;

    public virtual ICollection<ProductShop> ProductShops { get; set; } = new List<ProductShop>();
}
