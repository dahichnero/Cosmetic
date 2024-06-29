using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public string NameIngredient { get; set; } = null!;

    public string? Description { get; set; }

    public int Irritant { get; set; }

    public virtual Irritant IrritantNavigation { get; set; } = null!;

    public virtual ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();
}
