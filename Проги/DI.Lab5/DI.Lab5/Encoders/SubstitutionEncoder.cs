using DI.Lab5.Base;
using System.Text;

namespace DI.Lab5.Realization.Encoders
{
    /// <summary>
    /// Шифратор, основанный на подстановках
    /// </summary>
    public sealed class SubstitutionEncoder : IEncoder
    {
        /// <summary>
        /// Подстановка. Представляет собой номера мест шифрованного
        /// текста, на которые попадает каждая i-ый символ исхоного текста
        /// 
        /// Пример. 
        /// Исходные данные:
        /// Substitution = [2, 1, 4, 5, 3], Исходный текст: Hello
        /// Результат перестановки (шифрации), который должен быть: Eholl
        /// </summary>
        public ICollection<int> Substitution { get; private set; }

        /// <summary>
        /// Подстановка задается только для группы символов одного сообщения.
        /// Группа должна быть меньше либо равна сообщению.
        /// 
        /// Пример.
        /// Сообщение - Hello World
        /// Группа состоит из 4 символов. 
        /// Подстановка для группы = [4, 3, 2, 1]
        /// Сообщение, разделенное на группы: [Hell][o Wo][rld]
        /// Закодированное сообщение: [lleH][oW o][dlr]
        /// </summary>
        /// <param name="groupCapacity">Количество символов в группе</param>
        /// <param name="substitution">Подстановка для группы</param>
        /// <exception cref="ArgumentException">Генерируется, если аргументы заданы неверно</exception>
        public SubstitutionEncoder(int groupCapacity, ICollection<int> substitution)
        {
            if (groupCapacity <= 0) 
                throw new ArgumentException("Размерность группы должна быть положительной");

            if (substitution.Count != groupCapacity)
                throw new ArgumentException("Размерность подстановки не соответствует " +
                    "размерности группы");

            // Сумма арифметической прогрессии
            int arifSum = (1 + groupCapacity) * groupCapacity / 2;

            if (substitution.Sum(i => i) != arifSum)
                throw new ArgumentException("Заданная подстановка не может быть определена " +
                    "для указанной группы");

            Substitution = substitution;
        }
        public string Encode(string message)
        {
            if (Substitution.Count > message.Length)
                throw new ArgumentException("Заданная подстановка не может использоваться " +
                    "для заданного сообщения");

            StringBuilder encSB = new StringBuilder();

            char?[] subs = new char?[Substitution.Count];

            for(int i = 0; i < message.Length; i++)
            {
                int newPosInGroup = Substitution.ElementAt(
                    i % Substitution.Count);
                subs[newPosInGroup - 1] = message[i];
                if((i + 1) % Substitution.Count == 0)
                {
                    encSB.Append(subs.Select(s => s.Value).ToArray());
                    subs = new char?[Substitution.Count];
                }
            }
            
            encSB.Append(subs
                    .Where(s => s != null)
                    .Select(s => s.Value)
                    .ToArray());

            return encSB.ToString();
        }

        public string Decode(string encoded)
        {
            throw new NotImplementedException();
        }

    }
}
