using DI.Lab5.Base;
using DI.Lab5.Realization.Exceptions;
using DI.Lab5.Realization.Extensions;
using System.Text;

namespace DI.Lab5.Realization.Encoders
{
    public class RotatingGrilleCipherEncoder : IEncoder
    {
        public IGrille _grille { get; init; }

        public RotatingGrilleCipherEncoder(IGrille grille)
        {
            _grille = grille;
        }

        private bool IsMessageNormalized(string message)
        {
            int N = _grille.Grille.Count;
            if (message.Length < N * N || (message.Length % (N * N)) != 0)
                return false;
            return true;
        }

        private string NormalizeMessage(string message)
        {
            int N = _grille.Grille.Count;
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

        private List<List<List<char>>> MatrixVariations(string normalizedMsg)
        {
            var variations = new List<List<List<char>>>();
            int msgIndex = 0;
            while (msgIndex < normalizedMsg.Length)
            {
                var matrixVariation = _grille.Grille.Clone();
                var symbolsInVariation = matrixVariation.Count;
                for (int turn = 0; turn < 4; turn++)
                {
                    variations.Add(matrixVariation);
                    if (turn % 2 == 0)
                    {
                        _grille.RotateOn90DegClockwise();
                        matrixVariation = _grille.RotateOn90DegClockwise();

                    }
                    else if (turn % 2 == 1)
                    {
                        matrixVariation = _grille.TurnOver();
                    }
                    msgIndex += symbolsInVariation;
                }
            }
            return variations;
        }

        private List<List<List<char>>> FilledMatrixVariations(string normalizedMsg)
        {
            int msgIndex = 0;
            var matrixes = new List<List<List<char>>>();
            while (msgIndex < normalizedMsg.Length)
            {
                var matrixVariation = _grille.Grille.Clone();
                int N = matrixVariation.Count;
                for(int turn = 0; turn < 4; turn++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < matrixVariation[i].Count; j++)
                        {
                            if (matrixVariation[i][j] == 'X')
                            {
                                matrixVariation[i][j] = normalizedMsg[msgIndex];
                                msgIndex++;
                            }
                        }
                    }
                    matrixes.Add(matrixVariation);
                    if(turn % 2 == 0)
                    {
                        _grille.RotateOn90DegClockwise();
                        matrixVariation = _grille.RotateOn90DegClockwise();

                    }
                    else if(turn % 2 == 1)
                    {
                        matrixVariation = _grille.TurnOver();
                    }
                }
            }
            return matrixes;
        }

        private string EncodedMessage(List<List<List<char>>> matrixVariations, string normalizedMsg, int N)
        {
            StringBuilder encodedBuilder = new StringBuilder(normalizedMsg);
            int mult = normalizedMsg.Length / N;
            for(int m = 0; m < matrixVariations.Count; m++)
            {
                int frameOffset = (m / N) * N * N;
                for(int i = 0; i < matrixVariations[m].Count; i++)
                {
                    var matrixOffset = i * N;
                    for(int j = 0; j < matrixVariations[m][i].Count; j++)
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
            var matrixVariations = FilledMatrixVariations(normalizedMsg);
            return EncodedMessage(matrixVariations, normalizedMsg, _grille.Grille.Count);
        }

        private List<List<List<char>>> OverlayVariations(List<List<List<char>>> variations, string encoded)
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

        public string Decode(string encoded)
        {
            if (!IsMessageNormalized(encoded))
                throw new BadEncodedMessageException();

            int N = _grille.Grille.Count;
            var variations = MatrixVariations(encoded);
            //var overlayed = OverlayVariations(variations, encoded);
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
