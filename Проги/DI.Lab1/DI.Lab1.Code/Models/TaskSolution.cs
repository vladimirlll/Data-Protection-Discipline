using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Lab1.Code.Models
{
    public class TaskSolution
    {
        public IEnumerable<double> SolutionSelection { get; }


        public double Solution { get; }

        public TaskSolution(IEnumerable<double> solutionSelection, double solution)
        {
            SolutionSelection = solutionSelection;
            Solution = solution;
        }
    }
}
