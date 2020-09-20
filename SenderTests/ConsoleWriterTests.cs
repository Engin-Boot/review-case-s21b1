using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sender;
using Xunit;

namespace SenderTests
{

    public class ConsoleWriterTests
    {
        public Func<string, string[]> testFunc = line => new string[] { "Passed" };
        ConsoleWriter writer = new ConsoleWriter();

        [Fact]
        public void GivenRowDetailsTestForWritableFormat()
        {
            string[] rows = new string[]{"4/27/2020 9:14,what does this help,ajay"};
            string[] actual = writer.GetDataInWritableFormat(rows, 0, 1);
            string[] expected =
                {"4/27/2020 9:14 what", "4/27/2020 9:14 does", "4/27/2020 9:14 this", "4/27/2020 9:14 help"};
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.Equal(expected[i],actual[i]);
            }
        }

        [Fact]
        public void TestGetRowFromLineInvokesPassedFunc()
        {
            
            string[] result = writer.GetRowFromLine("test line", testFunc);
            string expected = "Passed";
            Assert.Equal(expected,result[0]);
        }

        [Fact]
        public void TestGetSeriesOfWordsInvokesPassedFunc()
        {
            string[] result = writer.GetSeriesOfWords("test line", testFunc);
            string expected = "Passed";
            Assert.Equal(expected, result[0]);
        }
    }
}
