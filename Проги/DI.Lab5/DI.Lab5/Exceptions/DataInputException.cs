namespace DI.Lab5.Realization.Exceptions
{
    abstract public class DataInputException : Exception
    {
        public DataInputException(string msg)
            :base(msg)
        { }
    }
}
