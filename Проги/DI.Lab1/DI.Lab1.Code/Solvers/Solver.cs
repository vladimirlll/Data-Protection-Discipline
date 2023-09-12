using DI.Lab1.Code.Models;

namespace DI.Lab1.Code.Solvers
{
    public class Solver : ITaskSolver
    {
        private readonly TaskData _data;

        public Solver(TaskData data) => _data = data;

        public TaskSolution Solve()
        {
            return new TaskSolution(new List<double> { 1, 2}, 1);
        }
    }
}
