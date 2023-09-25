namespace DI.Lab2.Base.Exceptions
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
