namespace DI.Lab5.Base
{
    public interface IGrille
    {
        /// <summary>
        /// Решетка в виде матрицы символов, состоящей из элементов ' ' и 'X'. 'X' - означает отверстие в решетке
        /// </summary>
        List<List<char>> Grille { get; init; }

        /// <summary>
        /// Поворот решетки на 90 градусов по часовой стрелке
        /// </summary>
        /// <returns>Повернутая решетка</returns>
        List<List<char>> RotateOn90DegClockwise();
    }
}
