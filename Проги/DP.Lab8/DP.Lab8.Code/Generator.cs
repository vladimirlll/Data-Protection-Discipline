namespace DP.Lab8.Code
{
    public class Generator
    {
        private long _initSeed;                          // изначальное значение, задаваемое в конструкторе (не изменяется)
        private long _currentVal;                        // текущее значение последовательности
        private long _a = 48271;                         // множитель
        private long _m = (int)((long)1 << 31 - 1);      // int.MaxValue (2^31 - 1)

        public Generator(int seed)
        {
            if(seed < 0 || seed > _m)
            {
                throw new ArgumentOutOfRangeException("Начальное значение должно быть >= 0 и <= " + _m.ToString());
            }
            _initSeed = seed;
            _currentVal = seed;
        }


        public int Next()
        {
            _currentVal = _a * _currentVal % _m;
            return (int)_currentVal;
        }

        public void Reset() => _currentVal = _initSeed;
    }
}
