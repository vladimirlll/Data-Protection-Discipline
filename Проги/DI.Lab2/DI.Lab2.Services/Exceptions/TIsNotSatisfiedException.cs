namespace DI.Lab2.Services.Exceptions
{
    public class TIsNotSatisfiedException : ScramblerSettingException
    {
        public TIsNotSatisfiedException(double T)
            : base($"Заданное значение T не соответствует условиям")
        { }
    }
}
