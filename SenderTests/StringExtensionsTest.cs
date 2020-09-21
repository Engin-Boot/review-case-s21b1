using System;
using Xunit;

namespace SenderTests
{
    public class StringExtensionsTest
    {
        [Fact]
        public void TestStringContainsByIgnoringCase()
        {
            string subString = "IamSubString";
            string mainString = "IambigStringIIncludeiamsubstring";
            Assert.True(mainString.Contains(subString, StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public void RaiseExceptionIfSubstringIsNull()
        {
            string subString = null;
            string mainString = "IambigStringIIncludeiamsubstring";
            Assert.Throws<ArgumentNullException>(() => mainString.Contains(subString, StringComparison.OrdinalIgnoreCase));
        }

        
    }
}
