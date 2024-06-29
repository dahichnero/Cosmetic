using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class ProductShop
{
    public int Product { get; set; }

    public int Shop { get; set; }

    public string? Link { get; set; }

    public int ProductShopId { get; set; }

    public virtual Product ProductNavigation { get; set; } = null!;

    public virtual Shop ShopNavigation { get; set; } = null!;
}
