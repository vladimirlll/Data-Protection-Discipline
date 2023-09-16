using DI.Lab5.Base.Models;

namespace DI.Lab5.Base
{
    public interface IPermutationEncoder
    {
        public string Encode(string message);
        public string Decode(string encoded);
    }
}
