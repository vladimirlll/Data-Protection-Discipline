namespace DP.Lab5.Service.Exceptions
{
    public abstract class EncoderException : Exception
    {
        public EncoderException(string msg)
            : base(msg)
        { }
    }
}
