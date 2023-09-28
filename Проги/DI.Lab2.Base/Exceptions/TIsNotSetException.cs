namespace DI.Lab2.Base.Exceptions
{
    public class TIsNotSetException : ScramblerSettingException
    {
        public TIsNotSetException()
            : base("Длительность большого интервала еще не установлена. " +
                  "Необходимо ее установить")
        { }
    }
}
