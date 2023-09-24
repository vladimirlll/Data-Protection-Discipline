using DI.Lab2.Base.Models;

namespace DI.Lab2.Base.Algorithms
{
    public class PhoneMessageScrambler : Scrambler
    {
        public double MessageDuration { get; set; }

        public PhoneMessageScrambler(ScramblerSettings settings,
            double messageDuration)
            :base(settings)
        {
            MessageDuration = messageDuration;
        }

        public override double InputSignalValueAt(double time)
        {
            throw new NotImplementedException();
        }

        public override double OutputSignalValueAt(double time)
        {
            throw new NotImplementedException();
        }
    }
}
