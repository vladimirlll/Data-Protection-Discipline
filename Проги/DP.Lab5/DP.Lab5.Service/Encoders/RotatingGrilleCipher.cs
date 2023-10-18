using DP.Lab5.Service.Exceptions;
using DP.Lab5.Service.Extensions;
using DP.Lab5.Service.Repository;
using System.Text;

namespace DP.Lab5.Service.Encoders
{
    public class RotatingGrilleCipherEncoder
    {
        public SquareGrilleRepository _repository { get; init; }
        /// <summary>
        /// Заполненные вариации поворота матрицы решетки. Заполняется только после работы методов Encode
        /// </summary>
        public List<List<List<char>>> FilledMatrixVariations { get; } = new List<List<List<char>>>();

        /// <summary>
        /// Заполненная решетка. Заполняется только после работы методов Encode
        /// </summary>
        public List<List<char>> FilledGrille { get; } = new List<List<char>>();

        public string NormalizedMessage { get; private set; } = "";

        public RotatingGrilleCipherEncoder(SquareGrilleRepository repository)
        {
            _repository = repository;
        }

        private bool IsMessageNormalized(string message)
        {
            int N = _repository.GrilleMatrix.Count;
            if (message.Length < N * N || (message.Length % (N * N)) != 0)
                return false;
            return true;
        }

        private string NormalizeMessage(string message)
        {
            int N = _repository.GrilleMatrix.Count;
            var normalizedMsg = message;

            if (!IsMessageNormalized(normalizedMsg))
            {
                Random rnd = new Random();
                StringBuilder builder = new StringBuilder(normalizedMsg);
                while (!IsMessageNormalized(builder.ToString()))
                {
                    char addSym = (char)rnd.Next('А', 'Я' + 1);
                    builder.Append(addSym);
                }
                normalizedMsg = builder.ToString();
            }
            return normalizedMsg;
        }

        private List<List<List<char>>> CreateMatrixVariations(string normalizedMsg)
        {
            var variations = new List<List<List<char>>>();
            var initialGrille = _repository.GrilleMatrix;
            var variation = _repository.GrilleMatrix;
            var msgIndex = 0;

            while (msgIndex < normalizedMsg.Length)
            {
                for (int i = 0; i < 4; i++)
                {
                    variations.Add(variation);
                    variation = variation.RotateOn90DegClockwise()
                        .Select(row => row.ToList()).ToList();
                }
                msgIndex += variation.Count * variation.Count;
            }

            return variations;
        }

        private List<List<List<char>>> FillMatrixVariations(string normalizedMsg, List<List<List<char>>> variations)
        {
            int msgIndex = 0;
            var filledVariations = new List<List<List<char>>>();

            foreach (var variation in variations)
            {
                filledVariations.Add(variation.Clone());
            }

            foreach (var variation in filledVariations)
            {
                for (int i = 0; i < variation.Count; i++)
                {
                    for (int j = 0; j < variation[i].Count; j++)
                    {
                        if (variation[i][j] == 'X')
                        {
                            variation[i][j] = normalizedMsg[msgIndex];
                            msgIndex++;
                        }
                    }
                }
            }

            return filledVariations;
        }

        private string EncodedMessage(List<List<List<char>>> matrixVariations, string normalizedMsg, int N)
        {
            StringBuilder encodedBuilder = new StringBuilder(normalizedMsg);
            int mult = normalizedMsg.Length / N;
            for (int m = 0; m < matrixVariations.Count; m++)
            {
                int frameOffset = (m / N) * N * N;
                for (int i = 0; i < matrixVariations[m].Count; i++)
                {
                    var matrixOffset = i * N;
                    for (int j = 0; j < matrixVariations[m][i].Count; j++)
                    {
                        if (matrixVariations[m][i][j] != ' ')
                            encodedBuilder[frameOffset + matrixOffset + j] = matrixVariations[m][i][j];
                    }
                }
            }
            return encodedBuilder.ToString();
        }

        public string Encode(string message)
        {
            var normalizedMsg = NormalizeMessage(message);
            NormalizedMessage = normalizedMsg;
            var variations = CreateMatrixVariations(normalizedMsg);
            var filledVariations = FillMatrixVariations(normalizedMsg, variations);
            foreach (var filled in filledVariations)
            {
                FilledMatrixVariations.Add(filled.Clone());
            }

            FilledMatrixVariations.Add(UniteVariations(filledVariations));

            return EncodedMessage(filledVariations, normalizedMsg, _repository.GrilleMatrix.Count);
        }

        private List<List<char>> UniteVariations(List<List<List<char>>> variations)
        {
            List<List<char>> result = new List<List<char>>();

            for (int i = 0; i < _repository.GrilleMatrix.Count; i++)
            {
                result.Add(new List<char>());
                for (int j = 0; j < _repository.GrilleMatrix[i].Count; j++)
                {
                    result[i].Add(' ');
                }
            }

            for (int v = 0; v < variations.Count; v++)
            {
                for (int i = 0; i < variations[v].Count; i++)
                {
                    for (int j = 0; j < variations[v][i].Count; j++)
                    {
                        if (variations[v][i][j] != ' ')
                        {
                            result[i][j] = variations[v][i][j];
                        }
                    }
                }
            }

            return result;
        }


        /*private List<List<List<char>>> OverlayVariations(List<List<List<char>>> variations, string encoded)
        {
            var encodedIndex = 0;
            List<List<List<char>>> overlayed = new List<List<List<char>>>();
            var matrixSide = _grille.Grille.Count;
            var matrixSize = matrixSide * matrixSide;
            for (int m = 0; m < encoded.Length / matrixSize; m++)
            {
                overlayed.Add(new List<List<char>>());
                for (int i = 0; i < matrixSide; i++)
                {
                    overlayed[m].Add(new List<char>());
                    for (int j = 0; j < matrixSide; j++)
                    {
                        overlayed[m][i].Add(' ');
                    }
                }
            }
            while (encodedIndex < encoded.Length)
            {
                var matrixIndex = encodedIndex / matrixSize;
                var matrixRowIndex = encodedIndex % matrixSize / matrixSide;
                var matrixRowColIndex = encodedIndex % matrixSize % matrixSide;
                overlayed[matrixIndex][matrixRowIndex][matrixRowColIndex] = encoded[encodedIndex];
            }
            return overlayed;
        }
        */

        public string Decode(string encoded)
        {
            if (!IsMessageNormalized(encoded))
                throw new BadEncodedMessageException();

            int N = _repository.GrilleMatrix.Count;
            var variations = CreateMatrixVariations(encoded);
            var decodedSB = new StringBuilder();
            for (int m = 0; m < variations.Count; m++)
            {
                int frameOffset = (m / N) * N * N;
                for (int i = 0; i < variations[m].Count; i++)
                {
                    var matrixOffset = i * N;
                    for (int j = 0; j < variations[m][i].Count; j++)
                    {
                        if (variations[m][i][j] != ' ')
                        {
                            decodedSB.Append(encoded[frameOffset + matrixOffset + j]);
                        }
                    }
                }
            }

            return decodedSB.ToString();
        }

    }
}
