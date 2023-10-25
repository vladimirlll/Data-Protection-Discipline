using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DP.Lab6.Presentational
{
    public class ThrithemiusEncoder
    {
        private string _alphabet;
        private string _keyWord;
        private string _uniqueKeyWord;
        private int _rows, _cols;
        private List<List<char>> _table = new List<List<char>>();

        public string Alphabet => _alphabet;
        public string KeyWord => _keyWord;
        public string UniqueKeyWord => _uniqueKeyWord;
        public List<List<char>> Table => _table;


        public ThrithemiusEncoder(string keyWord)
        {
            _alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            _alphabet += " ,.";
            _keyWord = keyWord.ToLower();
            _uniqueKeyWord = _keyWord.Unique();
            _rows = 6;
            _cols = 6;
            _table = CreateTable();
        }

        public ThrithemiusEncoder(string alphabet, string keyWord)
        {
            _alphabet = alphabet;
            _keyWord = keyWord.ToLower();
            _uniqueKeyWord = _keyWord.Unique();

            int lastDivider = -1;
            for(int i = 2; i <= (_alphabet.Length - 1); i++)
            {
                if (_alphabet.Length % 2 == 0)
                    lastDivider = i;
            }

            _rows = lastDivider;
            _cols = _alphabet.Length / _rows;
            _table = CreateTable();
        }


        public string Encode(string text)
        {
            StringBuilder encodedBuilder = new StringBuilder();
            foreach (var sym in text)
            {
                encodedBuilder.Append(GetUnderElement(sym));
            }

            return encodedBuilder.ToString();
        }

        public string Decode(string encoded)
        {
            StringBuilder encodedBuilder = new StringBuilder();
            foreach (var sym in encoded)
            {
                encodedBuilder.Append(GetAboveElement(sym));
            }

            return encodedBuilder.ToString();
        }

        public List<List<char>> CreateTable()
        {
            var table = new List<List<char>>();
            var restOfAlphabetSymbols = _alphabet.Exclude(_uniqueKeyWord);
            var stringInTable = _uniqueKeyWord + restOfAlphabetSymbols;

            for (int i = 0; i < _rows; i++)
            {
                table.Add(new List<char>());
                for (int j = 0; j < _cols; j++)
                {
                    var sym = stringInTable[i * _cols + j];
                    table[i].Add(sym);
                }
            }

            return table;
        }
        
        private int GetPositionOfElementInTable(char element)
        {
            int i = 0;
            int strLength = _rows * _cols;
            while (i < strLength && _table[i / _cols][i % _cols] != element)
            {
                i++;
            }

            if (i != strLength)
            {
                return i;
            }
            else 
                throw new ArgumentOutOfRangeException($"Символ - {element}, искомый в таблице, не найден");
        }

        public char GetAboveElement(char element)
        {
            var strLength = _rows * _cols;
            var pos = GetPositionOfElementInTable(element);

            int newPos = (pos - _cols);
            if (newPos < 0) newPos += strLength;
            return _table[newPos / _cols][newPos % _cols];
        }

        public char GetUnderElement(char element)
        {
            var strLength = _rows * _cols;
            var pos = GetPositionOfElementInTable(element);

            int newPos = (pos + _cols) % strLength;
            return _table[newPos / _cols][newPos % _cols];
        }
    }
}
