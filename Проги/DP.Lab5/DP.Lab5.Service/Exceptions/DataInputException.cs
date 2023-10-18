namespace DP.Lab5.Service.Exceptions
{
    abstract public class DataInputException : Exception
    {
        public DataInputException(string msg)
            : base(msg)
        { }
    }
}
