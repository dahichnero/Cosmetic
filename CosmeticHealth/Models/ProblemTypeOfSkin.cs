using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class ProblemTypeOfSkin
{
    public int Problem { get; set; }

    public int TypeOfSkin { get; set; }

    public int ProductTypeId { get; set; }

    public virtual Problem ProblemNavigation { get; set; } = null!;

    public virtual TypeOfSkin TypeOfSkinNavigation { get; set; } = null!;
}
