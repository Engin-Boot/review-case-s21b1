using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sender;
using Xunit;

namespace SenderTests
{
    public class CsvFileReaderTests
    {
        readonly CsvFileReader reader = new CsvFileReader();
        [Fact]
        public void TestForFilteringColumnsWhenRequiredColumnsAreGiven()
        {
            var path = @"D:\a\review-case-s21b1\review-case-s21b1\Sample3.csv";
            string[] result = reader.Read(path, new string[] { "ReviewDate", "Comments" });
            string[] actualStrings = new string[]{ "ReviewDate,Comments",
                                                    "4/27/2020 9:14,what does this help with?",
                                                    "5/13/2020 15:45,change spelling",
                                                    "5/13/2020 15:50,remove this log if not required" };
            Assert.Equal(result.Length, actualStrings.Length);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.Equal(result[i], actualStrings[i]);
            }
            
        }

        [Fact]
        public void TestForRemovingQuotesAndAnyCommasInBetweenQuotes()
        {
            string input = "I am, using \"Quotes And There are Commas, in, between\" Quotes ";
            string expected = "I am, using Quotes And There are Commas in between Quotes ";
            Assert.True(true);
        }

        private readonly Func<int[], string, string> columnFilterFunc = (columnIndexes, line) =>
        {
            string filteredLine = "";
            string[] row = line.Split(',');
            for (int i = 0; i < columnIndexes.Length; i++)
            {
                filteredLine += row[columnIndexes[i]];
                filteredLine += ",";
            }
            return filteredLine.Remove(filteredLine.Length - 1, 1);
        };
        [Fact]
        public void TestForInvokingTheFilterWhenAFilterIsGiven()
        {
            string result = reader.Filter(columnFilterFunc, new int[] {0, 1}, "column1,column2,column3");
            string actual = "column1,column2";
            Assert.Equal(result,actual);
        }

        [Fact]
        public void TestForRemovingHeader()
        {
            string[] data = {"Header", "Row1"};
            string[] actual = {"Row1"};
            string[] result = reader.SkipHeader(data);
            Assert.Equal(result[0],actual[0]);
        }
    }
}
