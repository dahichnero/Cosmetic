using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class TypeOfProduct
{
    public int TypeOfProductId { get; set; }

    public string NameTypeOfProduct { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
