namespace DI.Lab2.Base.Exceptions
{
    public class NonPositiveMessageDurationException
        : DataInputException
    {
        public NonPositiveMessageDurationException(
            double duration) : base("Длительность сообщения = " +
                $"{duration} <= 0")
        { }
    }
}
