namespace DI.Lab2.Base.Exceptions
{
    public class NonPositiveCoeffException : DataInputException
    {
        public NonPositiveCoeffException(
            double value, 
            string coeffName) : base("Значение для коэффициента " +
            $"{coeffName} = {value} < 0")
        { }
    }
}
