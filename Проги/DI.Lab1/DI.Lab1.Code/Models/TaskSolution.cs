using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Lab1.Code.Models
{
    public class TaskSolution
    {
        public ICollection<double> SolutionSelection { get; set; } = new List<double>();

        public double Solution { get; set; }
    }
}
