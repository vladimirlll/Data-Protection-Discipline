namespace DI.Lab5.Realization.Exceptions
{
    public class InputCharMatrixBadSizeException : DataInputException
    {
        public InputCharMatrixBadSizeException() : base("Размеры символьной матрицы для решетки заданы неверно")
        {
        }
    }
}
