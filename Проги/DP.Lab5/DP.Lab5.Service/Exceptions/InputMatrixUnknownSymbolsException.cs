namespace DP.Lab5.Service.Exceptions
{
    public class InputMatrixUnknownSymbolsException : DataInputException
    {
        public InputMatrixUnknownSymbolsException()
            : base("Заданная матрица содержит символы, которые не соответсвуют условию")
        {

        }
    }
}
