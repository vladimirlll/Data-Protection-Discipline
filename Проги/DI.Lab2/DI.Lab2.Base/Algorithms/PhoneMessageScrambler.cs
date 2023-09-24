using DI.Lab2.Base.Exceptions;
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
            if (messageDuration <= 0)
                throw new NonPositiveMessageDurationException(
                    messageDuration);
            MessageDuration = messageDuration;
        }

        /// <summary>
        /// Вычисляет значение функции от момента времени
        /// X(t) = A*sin(alpha*t) + B*cos(beta * t) + t * C * cos(cos(gamma*t)),
        /// где t - момент времени
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public override double InputSignalValueAt(
            double time)
        {
            double result =
                Settings.A * Math.Sin(Settings.Alpha * time) +
                Settings.B * Math.Cos(Settings.Beta * time) +
                time * Settings.C * Math.Cos(Math.Cos(
                    Settings.Gamma * time));
            return result;
        }

        public override double OutputSignalValueAt(double time)
        {
            throw new NotImplementedException();
        }
    }
}
