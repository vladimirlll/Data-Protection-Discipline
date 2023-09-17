namespace DI.Lab5.Base
{
    public interface IEncoder
    {
        /// <summary>
        /// Шифрация сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>Закодированное сообщение</returns>
        public string Encode(string message);
        /// <summary>
        /// Дешифрация закодированного сообщения
        /// </summary>
        /// <param name="encoded">Закодированное сообщение</param>
        /// <returns>Исходное сообщение</returns>
        public string Decode(string encoded);
    }
}
