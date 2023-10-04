namespace DI.Lab5.Realization.Exceptions
{
    public class BadEncodedMessageException : EncoderException
    {
        public BadEncodedMessageException()
            : base("Состояние зашифрованного сообщения не соответствует условиям")
        { }
    }
}
