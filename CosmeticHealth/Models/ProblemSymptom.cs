using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class ProblemSymptom
{
    public int Problem { get; set; }

    public int Symptom { get; set; }

    public int ProductSyId { get; set; }

    public virtual Problem ProblemNavigation { get; set; } = null!;

    public virtual Symptom SymptomNavigation { get; set; } = null!;
}
