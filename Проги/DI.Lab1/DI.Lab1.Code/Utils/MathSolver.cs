namespace DI.Lab1.Code.Utils
{
    public static class MathSolver
    {
        public static double TwoDDistance(double x1,  double y1, double x2, double y2)
        {
            double xDiff = x2 - x1;
            double yDiff = y2 - y1;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }
    }
}
