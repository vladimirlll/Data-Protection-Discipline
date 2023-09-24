using DI.Lab2.Base.Models;

namespace DI.Lab2.Base.Algorithms
{
    public abstract class Scrambler
    {
        public ScramblerSettings Settings { get; init; }
        public Scrambler(ScramblerSettings settings) => 
            Settings = settings;

        public abstract double InputSignalValueAt(double time);
        public abstract double OutputSignalValueAt(double time);
    }
}
