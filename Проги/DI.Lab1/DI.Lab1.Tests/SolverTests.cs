using DI.Lab1.Code.Models;
using DI.Lab1.Code.Solvers;
using FluentAssertions;

namespace DI.Lab1.Tests
{
    public class SolverTests
    {
        [Fact]
        public void Solver_Solve_ReturnsSolution()
        {
            ObjectPlan p = new ObjectPlan(100, 100, 50, 60, 70, 30, 30);
            TaskData td = new TaskData(p, 0.6, 0.7);

            ITaskSolver s = new Solver(td);
            TaskSolution ts = s.Solve();

            ts.Solution.Should().BeOneOf(ts.SolutionSelection);
            ts.Solution.Should().Be(ts.SolutionSelection.Min());
        }
    }
}
