namespace DI.Lab2.Base.Exceptions
{
    public class NonPositiveTimeIntervalException : DataInputException
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
