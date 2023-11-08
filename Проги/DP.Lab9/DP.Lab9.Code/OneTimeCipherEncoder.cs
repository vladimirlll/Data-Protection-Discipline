using System.Text;

namespace DP.Lab9.Code
{
    public class OneTimeCipherEncoder
    {
        public List<int> Key { get; private set; } = new List<int>();
        public List<char> Alphabet { get; init; }
        public bool IsKeyProduced { get; private set; } = false;

        public OneTimeCipherEncoder()
        {
            Alphabet = GetAlphabet();
        }

        public string Encode(string msg)
        {
            Key = GenerateKey(msg);
            IsKeyProduced = true;
            StringBuilder encoded = new StringBuilder();

            for (int i = 0; i < Key.Count; i++)
            {
                int msgSymIndex = Alphabet.IndexOf(msg[i]);
                int cipherSymCode = (msgSymIndex + Key[i]) % Alphabet.Count;
                char cipherSym = Alphabet[cipherSymCode];
                encoded.Append(cipherSym);
            }

            return encoded.ToString();
        }

        public string Decode(string enc)
        {
            if(!IsKeyProduced)
            {
                throw new KeyNotFoundException("Нет ключа для расшифровки сообщения");
            }

            if(Key.Count != enc.Length)
            {
                throw new ArgumentOutOfRangeException("Существующий ключ от предыдущей шифровки\nне подходит для расшифровки данного сообщения");
            }

            StringBuilder decoded = new StringBuilder();

            for (int i = 0; i < Key.Count; i++)
            {
                int encodedIndex = Alphabet.IndexOf(enc[i]);
                int cipherSymCode = (encodedIndex - Key[i]);
                if (cipherSymCode < 0) cipherSymCode += Alphabet.Count;

                char cipherSym = Alphabet[cipherSymCode];
                decoded.Append(cipherSym);
            }

            return decoded.ToString();
        }




        private List<char> GetAlphabet()
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

        private List<int> GenerateKey(string msg)
        {
            List<int> key = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < msg.Length; i++)
            {
                key.Add(rnd.Next(0, Alphabet.Count));
            }

            return key;
        }
    }
}
