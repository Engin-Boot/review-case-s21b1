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
        public Func<string, string[]> testFunc = line => new string[]{"Passed"};
        ConsoleWriter writer = new ConsoleWriter();

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
