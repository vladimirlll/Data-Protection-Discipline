namespace DP.Lab5.Service.Exceptions
{
    public class BadEncodedMessageException : EncoderException
    {
        public BadEncodedMessageException()
            : base("Состояние зашифрованного сообщения не соответствует условиям")
        { }
    }
}
