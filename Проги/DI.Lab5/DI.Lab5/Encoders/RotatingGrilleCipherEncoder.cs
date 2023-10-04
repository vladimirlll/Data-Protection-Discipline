using DI.Lab5.Base;

namespace DI.Lab5.Realization.Encoders
{
    public class RotatingGrilleCipherEncoder : IEncoder
    {
        public IGrille _grille { get; init; }

        public RotatingGrilleCipherEncoder(IGrille grille)
        {
            _grille = grille;
        }

        public string Encode(string message)
        {

        }


        public string Decode(string encoded)
        {
            throw new NotImplementedException();
        }

    }
}
