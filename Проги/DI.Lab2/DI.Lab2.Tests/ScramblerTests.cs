using DI.Lab2.Base.Algorithms;
using DI.Lab2.Base.Models;

namespace DI.Lab2.Tests
{
    public class ScramblerTests
    {
        private Scrambler scrambler;

        public ScramblerTests()
        {
            ScramblerSettings.Builder builder = new 
                ScramblerSettings.Builder();

            var settings = builder.SetA(1)
                .SetB(1)
                .SetC(1)
                .SetAlpha(1)
                .SetBeta(1)
                .SetGamma(1)
                .SetT(1)
                .Sett(0.5).Build();


            scrambler = new PhoneMessageScrambler(settings, 10);
        }

        // Tests
    }
}
