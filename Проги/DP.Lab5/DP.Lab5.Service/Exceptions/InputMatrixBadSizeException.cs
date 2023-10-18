namespace DP.Lab5.Service.Exceptions
{
    public class InputMatrixBadSizeException : DataInputException
    {
        public InputMatrixBadSizeException() : base("Размеры символьной матрицы для решетки заданы неверно")
        {
        }
    }
}
