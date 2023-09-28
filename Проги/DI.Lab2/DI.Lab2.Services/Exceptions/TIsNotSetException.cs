namespace DI.Lab2.Services.Exceptions
{
    public class TIsNotSetException : ScramblerSettingException
    {
        public TIsNotSetException()
            : base("Длительность большого интервала еще не установлена. " +
                  "Необходимо ее установить")
        { }
    }
}
