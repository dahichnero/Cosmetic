using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class Irritant
{
    public int IrritantId { get; set; }

    public string IrritantName { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
