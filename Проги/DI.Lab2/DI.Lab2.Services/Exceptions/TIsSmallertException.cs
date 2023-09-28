namespace DI.Lab2.Services.Exceptions
{
    /// <summary>
    /// Исключение, если длительность большого интервала 
    /// меньше длительности меньшего интервала
    /// </summary>
    public class TIsSmallertException : ScramblerSettingException
    {
        public TIsSmallertException()
            :base("Длительность большого временного интервала " +
                 "меньше длительного меньшего интервала")
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="T">Длительность большого интервала</param>
        /// <param name="t">Длительность малого интервала</param>
        public TIsSmallertException(double T, double t)
            :base("Длительность большого временного интервала = " +
                 $"{T} меньше длительности меньшего интервала = {t}")
        { }
    }
}
