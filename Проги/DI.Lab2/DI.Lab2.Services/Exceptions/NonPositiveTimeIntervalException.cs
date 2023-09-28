namespace DI.Lab2.Services.Exceptions
{
    public class NonPositiveTimeIntervalException : ScramblerSettingException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="interval">Неположительный временной 
        /// интервал</param>
        public NonPositiveTimeIntervalException(double interval)
            :base($"Задан неположительный временной интервал")
        { }
    }
}
