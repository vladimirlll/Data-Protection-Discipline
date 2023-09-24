namespace DI.Lab2.Base.Exceptions
{
    /// <summary>
    /// Исключение, если комбинация длительности большого 
    /// интервала и длительности меньшего интервала не подходит
    /// по делению
    /// </summary>
    public class TDividetIsNotSatisfiedException
        : DataInputException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="T">Длительность большого интервала</param>
        /// <param name="t">Длительность малого интервала</param>
        public TDividetIsNotSatisfiedException(double T,
            double t)
            : base($"Частное {T} / {t} = {T/t} " +
                  $"не удовлетворяет условию деления")
        { }
    }
}
