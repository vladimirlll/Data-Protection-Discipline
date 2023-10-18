namespace DI.Lab5.Base
{
    public interface IGrille
    {
        /// <summary>
        /// Решетка в виде матрицы символов, состоящей из элементов ' ' и 'X'. 'X' - означает отверстие в решетке
        /// </summary>
        List<List<char>> Grille { get; init; }

        /// <summary>
        /// Текущая версия трансформированной изначальной матрицы-решетки <see cref="Grille"/>
        /// </summary>
        List<List<char>> TransformedGrille { get; }

        /// <summary>
        /// Поворачивает матрицу <see cref="TransformedGrille"/> по горизонтали без поворота изначальной матрицы и возвращает повернутую версию
        /// </summary>
        /// <returns>Повернутая матрица</returns>
        List<List<char>> TurnOver();

        /// <summary>
        /// Поворот решетки <see cref="TransformedGrille"/> на 90 градусов по часовой стрелке
        /// </summary>
        /// <returns>Повернутая решетка</returns>
        List<List<char>> RotateOn90DegClockwise();
    }
}
