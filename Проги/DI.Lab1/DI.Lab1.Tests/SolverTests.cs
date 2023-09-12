using DI.Lab1.Code.Models;
using DI.Lab1.Code.Solvers;
using FluentAssertions;
using System.Collections.Immutable;

namespace DI.Lab1.Tests
{
    public class SolverTests
    {
        [Fact]
        public void Solver_Solve_ReturnsSolution()
        {
            ObjectPlan p = new ObjectPlan.Builder()
                .SetXFence(100).SetYFence(100)
                .SetYWindow(70).SetXFirstWindow(50).SetXSecondWindow(60)
                .SetXInfSys(30).SetYInfSys(30)
                .Build();
            TaskData td = new TaskData(p, 0.6, 0.7);

            ITaskSolver s = new Solver(td);
            TaskSolution ts = s.Solve();

            ts.Solution.Should().BeOneOf(ts.SolutionSelection);
            ts.Solution.Should().Be(ts.SolutionSelection.Min());
        }

        [Fact]
        public void Solver_Solver_CreatesCorrectSolutionSelection()
        {
            ObjectPlan p = new ObjectPlan.Builder()
                .SetXFence(100).SetYFence(100)
                .SetYWindow(70).SetXFirstWindow(40).SetXSecondWindow(70)
                .SetXInfSys(10).SetYInfSys(30)
                .Build();
            TaskData td = new TaskData(p, 0.5, 0.7);

            ITaskSolver s = new Solver(td);
            TaskSolution ts = s.Solve();

            ts.SolutionSelection.Should().HaveCount(200);
            ts.SolutionSelection.Should().HaveElementAt(0, 0.0002);
        }
    }
}
