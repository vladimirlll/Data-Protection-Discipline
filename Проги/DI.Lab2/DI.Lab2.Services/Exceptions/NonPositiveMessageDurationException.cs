namespace DI.Lab2.Services.Exceptions
{
    public class NonPositiveMessageDurationException
        : ScramblerSettingException
    {
        public NonPositiveMessageDurationException(
            double duration) : base("Длительность сообщения = " +
                $"{duration} <= 0")
        { }
    }
}
