namespace DI.Lab5.Realization.Exceptions
{
    public class InputCharMatrixUnknownSymbolsException : DataInputException
    {
        public InputCharMatrixUnknownSymbolsException()
            :base("Заданная матрица содержит символы, которые не соответсвуют условию")
        {
            
        }
    }
}
