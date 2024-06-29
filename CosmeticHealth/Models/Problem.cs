using System;
using System.Collections.Generic;

namespace CosmeticHealth.Models;

public partial class Problem
{
    public int ProblemId { get; set; }

    public string ProblemName { get; set; } = null!;

    public double YearsToSolve { get; set; }

    public virtual ICollection<ProblemSymptom> ProblemSymptoms { get; set; } = new List<ProblemSymptom>();

    public virtual ICollection<ProblemTypeOfSkin> ProblemTypeOfSkins { get; set; } = new List<ProblemTypeOfSkin>();

    public virtual ICollection<ProductProblem> ProductProblems { get; set; } = new List<ProductProblem>();
}
