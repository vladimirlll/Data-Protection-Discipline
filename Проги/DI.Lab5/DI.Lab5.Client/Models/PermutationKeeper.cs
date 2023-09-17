using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Lab5.Client.Models
{
    /// <summary>
    /// Хранитель подстановки, выбираемой пользователем
    /// </summary>
    public class PermutationKeeper
    {
        private int _permutationLength;
        private ICollection<int> _permutation;

        public ICollection<int> Permutation 
        {
            get { return _permutation; }
            set
            {
                if (value.Count != _permutationLength
                    || value.Sum() != (1 + _permutationLength) *
                                    _permutationLength / 2)
                    throw new ArgumentException("Подстановка задана неверно");
                _permutation = value;
            }
        }

        public PermutationKeeper()
        {
            _permutationLength = 4;
            Permutation = new List<int>() { 4, 3, 2, 1 };
        }

        public void SetPermutationFromString(string permutationStr)
        {
            if (permutationStr.Length != _permutationLength)
                throw new ArgumentException("Подстановка в виде строки задана неверно");
            var permutationTemp = permutationStr.Select(d =>
            {
                if (!char.IsDigit(d))
                    throw new ArgumentException("Строка подстановки содержит нечисловое значение");
                return int.Parse(d.ToString());
            }).ToList();
            Permutation = permutationTemp;
        }
    }
}
