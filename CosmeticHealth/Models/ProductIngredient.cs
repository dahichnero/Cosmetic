using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class ProductIngredient
{
    public int Product { get; set; }

    public int Ingredient { get; set; }

    public double Procent { get; set; }

    public int ProductIngredientId { get; set; }

    public virtual Ingredient IngredientNavigation { get; set; } = null!;

    public virtual Product ProductNavigation { get; set; } = null!;
}
