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

        private bool CheckTimeMomentSatisfaction(double time)
        {
            if (time < 0 || time > MessageDuration)
                return false;
            return true;
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
            if (!CheckTimeMomentSatisfaction(time))
                throw new ArgumentOutOfRangeException("Момент времени " +
                    "выходит за пределы допустимых значений");

            double result =
                Settings.A * Math.Sin(Settings.Alpha * time) +
                Settings.B * Math.Cos(Settings.Beta * time) +
                time * Settings.C * Math.Cos(Math.Cos(
                    Settings.Gamma * time));
            return result;
        }

        public override double OutputSignalValueAt(double time)
        {
            if (!CheckTimeMomentSatisfaction(time))
                throw new ArgumentOutOfRangeException("Момент времени " +
                    "выходит за пределы допустимых значений");

            var curveBigSegmentInLineNum = int.Parse(
                    Math.Floor(time / Settings.T)
                    .ToString());

            var curveOldSmallSegmentInLineNum = int.Parse(
                    Math.Floor(time / Settings.t).ToString());
            var curveOldSmallSegmentInBigSegmentNum = 
                    curveOldSmallSegmentInLineNum %
                    int.Parse((Settings.T / Settings.t).ToString());

            var newCurveSmallSegmentInBigSegmentNum = Settings.Key
                .ToList()
                .IndexOf(curveOldSmallSegmentInBigSegmentNum);

            var newCurveSmallSegmentInLineNum =
                curveBigSegmentInLineNum * 
                (Settings.T / Settings.t) +
                newCurveSmallSegmentInBigSegmentNum;

            var startOldSmallSegmentTime = 
                curveOldSmallSegmentInLineNum * Settings.t;
            var diff = time - startOldSmallSegmentTime;

            var newTime = newCurveSmallSegmentInLineNum
                * Settings.t + diff;

            var y = InputSignalValueAt(newTime);


            return y;
        }
    }
}
