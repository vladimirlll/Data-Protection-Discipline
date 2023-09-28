using DI.Lab2.Services.Exceptions;
using DI.Lab2.Services.Models;
using DI.Lab2.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DI.Lab2.Services.Algorithms
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

        private bool IsBorderPoint(double time)
        {
            // Если это пограничная точка в большом сегменте,
            // то она делится само собой
            // на длительность малого интервала
            // и на длительность большого интервала нацело
            // и это не начало времени - 0
            var div = time / Settings.T;
            if (Math.Abs(div - Math.Truncate(div)) < 
                Constants.EPSILON && time > Constants.EPSILON)
                return true;
            return false;
        }

        private bool IsEndPoint(double time)
        {
            var diff = MessageDuration - time;
            if (Math.Abs(diff) < Constants.EPSILON)
                return true;
            return false;
        }

        private double OutputSignalValue(
            int bigSegmentNum,
            int oldSmallSegmentInLineNum,
            double time)
        {
            var oldSmallSegmentInBigSegmentNum =
                    oldSmallSegmentInLineNum %
                    int.Parse((Settings.T / Settings.t).ToString());

            var newCurveSmallSegmentInBigSegmentNum = Settings.Key
                .ToList()
                .IndexOf(oldSmallSegmentInBigSegmentNum);

            var newCurveSmallSegmentInLineNum =
                bigSegmentNum *
                (Settings.T / Settings.t) +
                newCurveSmallSegmentInBigSegmentNum;

            var startOldSmallSegmentTime =
                oldSmallSegmentInLineNum * Settings.t;
            var diff = time - startOldSmallSegmentTime;

            var newTime = newCurveSmallSegmentInLineNum
                * Settings.t + diff;

            var y = InputSignalValueAt(newTime);


            return y;
        }

        public override IEnumerable<double> OutputSignalValueAt(
            double time)
        {
            if (!CheckTimeMomentSatisfaction(time))
                throw new ArgumentOutOfRangeException("Момент времени " +
                    "выходит за пределы допустимых значений");

            List<double> results = new List<double>();

            var bigSegmentNum = int.Parse(
                    Math.Floor(time / Settings.T)
                    .ToString());

            var smallSegmentInLineNum = int.Parse(
                    Math.Floor(time / Settings.t).ToString());
            var additional = new List<double>();
            if (IsBorderPoint(time))
            {
                results.Add(OutputSignalValue(bigSegmentNum - 1,
                    smallSegmentInLineNum - 1, time));
            }
            if(!IsEndPoint(time))
                results.Add(OutputSignalValue(bigSegmentNum,
                    smallSegmentInLineNum, time));

            //results.AddRange(additional);

            return results;
        }
    }
}
