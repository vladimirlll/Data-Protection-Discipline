using DI.Lab2.Base.Exceptions;
using DI.Lab2.Base.Utils;

namespace DI.Lab2.Base.Models
{
    /// <summary>
    /// Настройка скрамблера через установка функции
    /// X(t) = A*sin(alpha*t) + B*cos(betta*t) + 
    /// t * C * cos(cos(gamma*t))
    /// </summary>
    public class ScramblerSettings
    {
        /// <summary>
        /// Коэффицент в функции
        /// </summary>
        public double A { get; private set; }
        /// <summary>
        /// Коэффицент в функции
        /// </summary>
        public double B { get; private set; }
        /// <summary>
        /// Коэффицент в функции
        /// </summary>
        public double C { get; private set; }
        /// <summary>
        /// Константа
        /// </summary>
        public double Alpha { get; private set; }
        /// <summary>
        /// Константа
        /// </summary>
        public double Beta { get; private set; }
        /// <summary>
        /// Константа
        /// </summary>
        public double Gamma { get; private set; }
        /// <summary>
        /// Длительность большого временного интервала, 
        /// на который будет делиться сообщение
        /// </summary>
        public double T { get; private set; }
        /// <summary>
        /// Длительность мальнего временного интервала, 
        /// на который будет делиться каждый большой интервал
        /// </summary>
        public double t { get; private set; }
        /// <summary>
        /// Ключ криптографического преобразования.
        /// Новые места отрезков, на которые должны перейти
        /// исходные отрезки
        /// </summary>
        public IEnumerable<int> Key { get; private set; }

        private ScramblerSettings() { }

        /// <summary>
        /// Строитель для <see cref="ScramblerSettings"/>
        /// </summary>
        public class Builder
        {
            private bool _isTSet = false;
            private bool _istSet = false;
            private ScramblerSettings _result = new ScramblerSettings()
            {
                A = 1,
                B = 1,
                C = 1,
                Alpha = 1,
                Beta = 1,
                Gamma = 1,
                T = 2,
                t = 0.33,
                k = new List<int> { 5, 3, 1, 4, 2, 0}
            };

            public Builder SetA(double a)
            {
                _result.A = a;
                return this;
            }

            public Builder SetB(double b)
            {
                _result.B = b;
                return this;
            }

            public Builder SetC(double c)
            {
                _result.C = c;
                return this;
            }

            public Builder SetAlpha(double alpha)
            {
                if (alpha <= 0) 
                    throw new NonPositiveCoeffException(alpha, "alpha");
                _result.Alpha = alpha;
                return this;
            }

            public Builder SetBeta(double beta)
            {
                if (beta <= 0)
                    throw new NonPositiveCoeffException(beta, "beta");
                _result.Beta = beta;
                return this;
            }

            public Builder SetGamma(double gamma)
            {
                if (gamma <= 0)
                    throw new NonPositiveCoeffException(gamma, "gamma");
                _result.Gamma = gamma;
                return this;
            }

            public Builder SetT(double T)
            {
                if (T < Constants.MIN_T || T > Constants.MAX_T)
                    throw new NonPositiveTimeIntervalException(T);
                _result.T = T;
                _isTSet = true;
                return this;
            }

            public Builder Sett(double t)
            {
                if (!_isTSet)
                    throw new TIsNotSetException();
                if (t <= 0)
                    throw new NonPositiveCoeffException(t, "t");
                if (t > _result.T)
                    throw new TIsSmallertException(_result.T, t);
                // T должно делиться на t на целое число n такое,
                // что n = m...10m, m - целое число < 10
                double n = _result.T / t;
                if (n - Math.Truncate(n) < Constants.EPSILON
                    && n >= Constants.M && n <= 10 * Constants.M)
                {
                    _result.t = t;
                    _istSet = true;
                    return this;
                }
                else throw new TDividetIsNotSatisfiedException(
                    _result.T, t);
            }

            public Builder SetKey(IEnumerable<int> key)
            {
                if (_istSet && _isTSet)
                {
                    if(key.Count() == 
                        double.Truncate(
                            _result.T / _result.t))
                    {
                        _result.Key = key;
                    }
                }

                return this;
            }

            public ScramblerSettings Build() => _result;
        }
    }
}
