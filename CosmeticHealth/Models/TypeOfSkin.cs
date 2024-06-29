using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class TypeOfSkin
{
    public int TypeOfSkinId { get; set; }

    public string TypeOfSkinName { get; set; } = null!;

    public string? HowToKnow { get; set; }

    public virtual ICollection<ProblemTypeOfSkin> ProblemTypeOfSkins { get; set; } = new List<ProblemTypeOfSkin>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
