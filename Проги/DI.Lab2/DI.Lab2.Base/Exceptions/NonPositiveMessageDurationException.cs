namespace DI.Lab2.Base.Exceptions
{
    public class NonPositiveMessageDurationException
        : DataInputException
    {
        public NonPositiveMessageDurationException(
            int duration) : base("Длительность сообщения = " +
                $"{duration} <= 0")
        { }
    }
}
