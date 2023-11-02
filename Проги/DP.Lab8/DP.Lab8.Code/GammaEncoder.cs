using System.Text;

namespace DP.Lab8.Code
{
    public class GammaEncoder
    {
        private readonly Generator _generator;


        public GammaEncoder(Generator generator)
        {
            _generator = generator;
        }

        public string Encode(string message)
        {
            _generator.Reset();
            StringBuilder encoded = new StringBuilder();

            foreach (var sym in message)
            {
                int keySym = _generator.Next() % short.MaxValue;
                int sumSym = sym ^ keySym;
                encoded.Append((char)sumSym);
            }

            return encoded.ToString();
        }

        public string Decode(string encoded)
        {
            _generator.Reset();
            StringBuilder decoded = new StringBuilder();

            foreach (var sym in encoded)
            {
                int keySym = _generator.Next() % short.MaxValue;
                int sumSym = sym ^ keySym;
                decoded.Append((char)sumSym);
            }

            return decoded.ToString();
        }
    }
}
