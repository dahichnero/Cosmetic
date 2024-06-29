using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class ProductProblem
{
    public int Product { get; set; }

    public int Problem { get; set; }

    public int ProductProblemId { get; set; }

    public virtual Problem ProblemNavigation { get; set; } = null!;

    public virtual Product ProductNavigation { get; set; } = null!;
}
