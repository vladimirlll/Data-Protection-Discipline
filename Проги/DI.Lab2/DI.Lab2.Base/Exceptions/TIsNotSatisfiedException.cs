namespace DI.Lab2.Base.Exceptions
{
    public class TIsNotSatisfiedException : DataInputException
    {
        public TIsNotSatisfiedException(double T)
            : base($"Заданное значение T не соответствует условиям")
        { }
    }
}
