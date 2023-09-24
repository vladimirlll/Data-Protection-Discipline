namespace DI.Lab2.Base.Exceptions
{
    public class TIsNotSetException : DataInputException
    {
        public TIsNotSetException()
            : base("Длительность большого интервала еще не установлена. " +
                  "Необходимо ее установить")
        { }
    }
}
