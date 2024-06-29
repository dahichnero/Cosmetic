using CosmeticHealth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CosmeticHealth.ViewModels
{
    public class ProblemViewModel : BaseViewModel, IDataErrorInfo
    {
        public ProblemViewModel()
        {
        }

        public ProblemViewModel(Problem problem)
        {
            ProblemId = problem.ProblemId;
            ProblemName = problem.ProblemName;
            YearsToSolve=problem.YearsToSolve;
        }

        public Problem ToProblem() => new Problem
        {
            ProblemId=ProblemId,
            ProblemName=ProblemName,
            YearsToSolve=YearsToSolve,
        };
        public string this[string columnName]
        {
            get
            {
                if (columnName == "ProblemName" && string.IsNullOrWhiteSpace(ProblemName))
                {
                    return "Название проблемы не может быть пустым!";
                }
                if (columnName == "ProblemName" && ProblemName.Length >= 200)
                {
                    return "Название проблемы не может содержать более 200 знаков!";
                }
                if (columnName == "YearsToSolve" && YearsToSolve < 1)
                {
                    return "Лечение должно занимать от года!";
                }
                return null!;
            }
        }

        public string Error => null!;

        public int ProblemId { get; set; }

        public string ProblemName { get; set; } = null!;

        public double YearsToSolve { get; set; }
    }
}
