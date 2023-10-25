using DP.Lab6.Presentational;
using FluentAssertions;
using System.Text;

namespace DP.Lab6.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void Unique_WithTwoSameLetters_ShouldReturnUniqueStrings()
        {
            string testStr = "префектура";

            string unique = testStr.Unique();

            unique.Should().BeEquivalentTo("префктуа");
        }

        [Fact]
        public void Exclude_WithNotTheSameString_ShouldReturnExcludedString()
        {
            string s1 = "";
            StringBuilder builder = new StringBuilder();
            for (char i = 'а'; i <= 'я'; i++)
                builder.Append(i);
            s1 = builder.ToString();
            s1 += " ,.";
            string s2 = "префктуа";

            string excluded = s1.Exclude(s2);

        }
    }
}
