using DI.Lab1.Code.Models;
using DI.Lab1.Code.Utils;
using System.Drawing;

namespace DI.Lab1.Code.Solvers
{
    public class Solver : ITaskSolver
    {
        private readonly TaskData _data;

        public Solver(TaskData data) => _data = data;

        public TaskSolution Solve()
        {
            TaskSolution sol = new TaskSolution();
            double step = _data.Plan.Xfence / Constants.RegionsCount;

            double infSysFirstWindowDist = MathSolver.TwoDDistance(_data.Plan.XfirstWindow, _data.Plan.Ywindow, 
                                                                    _data.Plan.XInfSys, _data.Plan.YInfSys);

            double infSysSecondWindowDist = MathSolver.TwoDDistance(_data.Plan.XsecondWindow, _data.Plan.Ywindow, 
                                                                    _data.Plan.XInfSys, _data.Plan.YInfSys);

            for(double x = 0; x <= _data.Plan.Xfence; x+= step)
            {

                double fenceFirstWindowDist = MathSolver.TwoDDistance(x, _data.Plan.Yfence, 
                                                                        _data.Plan.XfirstWindow, _data.Plan.Ywindow);

                double fenceSecondWindowDist = MathSolver.TwoDDistance(x, _data.Plan.Yfence,
                                                                        _data.Plan.XsecondWindow, _data.Plan.Ywindow);

                double firstWindowProb = (Constants.FirstWindowSecurityCoeff / fenceFirstWindowDist) 
                                            * _data.FWPenetrationProb 
                                            * (Constants.SecondWindowSecurityCoeff / infSysFirstWindowDist);

                double secondWindowProb = (Constants.FirstWindowSecurityCoeff / fenceSecondWindowDist)
                                            * _data.SWPenetrationProb
                                            * (Constants.SecondWindowSecurityCoeff / infSysSecondWindowDist);

                sol.SolutionSelection.Add(firstWindowProb);
                sol.SolutionSelection.Add(secondWindowProb);
            }

            sol.Solution = sol.SolutionSelection.Min();

            return sol;
        }
    }
}
