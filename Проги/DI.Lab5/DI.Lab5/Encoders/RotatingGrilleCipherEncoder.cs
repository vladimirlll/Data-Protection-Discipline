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
            int N = _grille.Grille.Count;
            int msgIndex = 0;
            var matrixes = new List<List<List<char>>>();
            while (msgIndex < normalizedMsg.Length)
            {
                var matrixVariation = _grille.Grille.Clone();
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
                    matrixVariation = _grille.RotateOn90DegClockwise();
                }
            }
            return matrixes;
        }

        private string EncodedMessage(List<List<List<char>>> matrixes, string normalizedMsg, int N)
        {
            StringBuilder encodedBuilder = new StringBuilder(normalizedMsg);
            int mult = normalizedMsg.Length / N;
            for(int m = 0; m < matrixes.Count; m++)
            {
                int frameOffset = (m / N) * N * N;
                for(int i = 0; i < matrixes[m].Count; i++)
                {
                    var matrixOffset = i * N;
                    for(int j = 0; j < matrixes[m][i].Count; j++)
                    {
                        if (matrixes[m][i][j] != ' ')
                            encodedBuilder[frameOffset + matrixOffset + j] = matrixes[m][i][j];
                    }
                }
            }
            return encodedBuilder.ToString();
        }

        public string Encode(string message)
        {
            var normalizedMsg = NormalizeMessage(message);
            var matrixVariations = MatrixVariations(normalizedMsg);
            return EncodedMessage(matrixVariations, normalizedMsg, _grille.Grille.Count);
        }


        public string Decode(string encoded)
        {
            if (!IsMessageNormalized(encoded))
                throw new BadEncodedMessageException();

            return encoded;
        }

    }
}
