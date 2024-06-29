using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class Symptom
{
    public int SymptomId { get; set; }

    public string NameSymptom { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<ProblemSymptom> ProblemSymptoms { get; set; } = new List<ProblemSymptom>();
}
