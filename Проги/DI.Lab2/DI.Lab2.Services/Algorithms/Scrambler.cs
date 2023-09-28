using DI.Lab2.Services.Models;
using System.Collections.Generic;

namespace DI.Lab2.Services.Algorithms
{
    public abstract class Scrambler
    {
        public ScramblerSettings Settings { get; private set; }
        public Scrambler(ScramblerSettings settings) => 
            Settings = settings;

        public abstract double InputSignalValueAt(double time);
        public abstract IEnumerable<double> OutputSignalValueAt(
            double time);
    }
}
