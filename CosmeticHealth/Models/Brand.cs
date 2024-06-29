using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string NameBrand { get; set; } = null!;

    public DateTime DateFound { get; set; }

    public double Rating { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
