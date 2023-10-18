using DP.Lab5.Service.Extensions;
using DP.Lab5.Service.Models;

namespace DP.Lab5.Service.Repository
{
    public class SquareGrilleRepository
    {
        private readonly SquareGrille _grille;

        /// <summary>
        /// Создает решетку по переданной матрице
        /// </summary>
        /// <param name="grille">Матрица</param>
        public SquareGrilleRepository(List<List<char>> grille)
        {
            _grille = new SquareGrille(grille);
        }

        /// <summary>
        /// Создает хранимую решетку рандомно
        /// </summary>
        /// <param name="k">Размер четверти решетки</param>
        public SquareGrilleRepository(int k)
        {
            _grille = new SquareGrille(k);
        }

        /// <summary>
        /// Матрица решетки с дырами
        /// </summary>
        public List<List<char>> GrilleMatrix => _grille.Grille.Clone();

        /// <summary>
        /// Матрица решетки на момент образования с числами и повернутыми четвертями
        /// </summary>
        public List<List<int>> NumMatrix => _grille.NumGrille.Clone();

    }
}
