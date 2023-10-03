namespace DI.Lab5.Base
{
    public interface IGrille
    {
        /// <summary>
        /// Решетка в виде матрицы символов, состоящей из элементов ' ' и 'X'. 'X' - означает отверстие в решетке
        /// </summary>
        List<List<char>> Grille { get; init; }
    }
}
