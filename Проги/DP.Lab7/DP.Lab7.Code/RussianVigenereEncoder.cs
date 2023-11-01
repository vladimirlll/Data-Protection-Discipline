using System.Text;

namespace DP.Lab7.Code
{
    public class RussianVigenereEncoder
    {
        private List<char> _alphabet = new List<char>();
        public List<char> Alphabet => _alphabet;

        private readonly string _key;
        public string Key => _key;

        public RussianVigenereEncoder(string key)
        {
            _alphabet = GetAlphabet();
            _key = key;
        }

        public List<char> GetAlphabet()
        {
            List<char> alphabet = new List<char>();

            for (char sym = 'А'; sym <= 'Я'; sym++)
            {
                alphabet.Add(sym);
            }

            for (char sym = 'а'; sym <= 'я'; sym++)
            {
                alphabet.Add(sym);
            }

            alphabet.AddRange(new List<char> { '.', ',', '!', '?', ' ', '\n', '\r' });

            return alphabet;
        }

        public string Encode(string plainText)
        {
            string normalizedKey = GetNormalizedKey(plainText);

            StringBuilder encoded = new StringBuilder();

            for (int i = 0; i < plainText.Length; i++)
            {
                int plainTextIndex = Alphabet.IndexOf(plainText[i]);
                int keyIndex = Alphabet.IndexOf(normalizedKey[i]);
                int sumIndex = (plainTextIndex + keyIndex) % Alphabet.Count;

                encoded.Append(Alphabet[sumIndex]);
            }

            return encoded.ToString();
        }

        public string GetNormalizedKey(string plainText)
        {
            StringBuilder normalized = new StringBuilder();

            for (int i = 0; i < plainText.Length; i++)
            {
                normalized.Append(Key[i % Key.Length]);
            }

            return normalized.ToString();
        }

        public string Decode(string encoded)
        {
            string normalizedKey = GetNormalizedKey(encoded);

            StringBuilder decoded = new StringBuilder();

            for (int i = 0; i < encoded.Length; i++)
            {
                int encodedIndex = Alphabet.IndexOf(encoded[i]);
                int keyIndex = Alphabet.IndexOf(normalizedKey[i]);
                int sumIndex = encodedIndex - keyIndex;
                if (sumIndex < 0) sumIndex += Alphabet.Count;

                decoded.Append(Alphabet[sumIndex]);
            }

            return decoded.ToString();
        }
    }
}
