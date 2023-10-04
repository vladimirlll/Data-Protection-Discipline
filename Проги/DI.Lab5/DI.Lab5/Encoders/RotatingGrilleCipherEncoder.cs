using DI.Lab5.Base;
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

        private string NormalizeMessage(string message)
        {
            int N = _grille.Grille.Count;
            var normalizedMsg = "";

            if(message.Length % N != 0)
            {
                Random rnd = new Random();
                StringBuilder builder = new StringBuilder(message);
                while (message.Length % N != 0)
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
                var matrixVariation = new List<List<char>>(_grille.Grille);
                for (int i = 0; i < N * N; i++)
                {
                    for (int j = 0; j < N; j++, i++)
                    {
                        if (matrixVariation[i][j] == 'X')
                            matrixVariation[i][j] = normalizedMsg[msgIndex];
                        msgIndex++;
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
            throw new NotImplementedException();
        }

    }
}
