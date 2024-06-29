using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Brand { get; set; }

    public int Type { get; set; }

    public string? Description { get; set; }

    public string HowUse { get; set; } = null!;

    public int? TypeOfSkin { get; set; }

    public string? Image { get; set; }

    public int Irritant { get; set; }

    public virtual Brand BrandNavigation { get; set; } = null!;

    public virtual Irritant IrritantNavigation { get; set; } = null!;

    public virtual ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();

    public virtual ICollection<ProductProblem> ProductProblems { get; set; } = new List<ProductProblem>();

    public virtual ICollection<ProductShop> ProductShops { get; set; } = new List<ProductShop>();

    public virtual TypeOfProduct TypeNavigation { get; set; } = null!;

    public virtual TypeOfSkin? TypeOfSkinNavigation { get; set; }
}
