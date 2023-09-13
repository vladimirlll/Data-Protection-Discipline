using DI.Lab1.Code.Models;
using DI.Lab1.Code.Solvers;

double XFence, YFence, YWindow, XFirstWindow, XSecondWindow,
    XInfSys, YInfSys, FirstWindowPP, SecondWindowPP;

Console.WriteLine("======================================================================================================\n");

do
{
    Console.WriteLine("Введите длину забора по X (должно быть < 50): ");
    XFence = double.Parse(Console.ReadLine());

} while (XFence >= 50 || XFence <= 0);

do
{
    Console.WriteLine("Введите длину забора по Y (должно быть < 50): ");
    YFence = double.Parse(Console.ReadLine());

} while (YFence >= 50 || YFence <= 0);

do
{
    Console.WriteLine("Введите координату Y обоих окон: ");
    YWindow = double.Parse(Console.ReadLine());

} while (YWindow >= YFence);

do
{
    Console.WriteLine("Введите координату X первого окна: ");
    XFirstWindow = double.Parse(Console.ReadLine());

} while (XFirstWindow >= XFence);

do
{
    Console.WriteLine("Введите координату X второго окна: ");
    XSecondWindow = double.Parse(Console.ReadLine());

} while (XSecondWindow >= XFence || (Math.Abs(XSecondWindow - XFirstWindow) < double.Epsilon) );

do
{
    Console.WriteLine("Введите координату X средства хранения информации: ");
    XInfSys = double.Parse(Console.ReadLine());

} while (XInfSys >= XFence);

do
{
    Console.WriteLine("Введите координату Y средства хранения информации: ");
    YInfSys = double.Parse(Console.ReadLine());

} while (YInfSys >= YFence);

do
{
    Console.WriteLine("Введите вероятность проникновения через первое окно: ");
    FirstWindowPP = double.Parse(Console.ReadLine());

} while (FirstWindowPP < 0 || FirstWindowPP > 1);

do
{
    Console.WriteLine("Введите вероятность проникновения через второе окно: ");
    SecondWindowPP = double.Parse(Console.ReadLine());

} while (SecondWindowPP < 0 || SecondWindowPP > 1);

ObjectPlan p = new ObjectPlan.Builder()
                .SetXFence(XFence).SetYFence(YFence)
                .SetYWindow(YWindow).SetXFirstWindow(XFirstWindow).SetXSecondWindow(XSecondWindow)
                .SetXInfSys(XInfSys).SetYInfSys(YInfSys)
                .Build();
TaskData td = new TaskData(p, FirstWindowPP, SecondWindowPP);

ITaskSolver s = new Solver(td);
TaskSolution ts = s.Solve();

Console.WriteLine("======================================================================================================\n");

Console.WriteLine("Выборка для значений: ");
for(int i = 0; i < ts.SolutionSelection.Count; i++)
{
    if (i % 2 == 0) Console.Write("\n");
    Console.Write(ts.SolutionSelection.ElementAt(i) + "\t");
}
Console.WriteLine($"\nРезультат проникновения: {ts.Solution}");