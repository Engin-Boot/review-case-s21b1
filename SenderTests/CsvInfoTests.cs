using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sender;
using Xunit;

namespace SenderTests
{
    public class CsvInfoTests
    {
        [Fact]
        public void GivenValidFilepathReturnsColumnNames()
        {
            var path = @"D:\a\review-case-s21b1\review-case-s21b1\Sample3.csv";
            string[] result = CsvInfo.GetColumns(path);
            string[] actual = new string[]{ "ReviewDate","Comments","user" };
            Assert.Equal(result.Length,actual.Length);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.Equal(result[i], actual[i]);                                        // missed proper naming result and actual
            }
        }

        [Fact]
        public void GivenAExistingColumnNameReturnsItsIndex()
        {
            string[] columnNames = new string[] { "ReviewDate", "Comments", "user" };
            int result = CsvInfo.GetColumnIndex(columnNames, "user");
            int actual = 2;
            Assert.Equal(result,actual);
        }

        [Fact]
        public void TestForFindingIndexOfInvalidColumnName()
        {
            string[] columnNames = new string[] { "ReviewDate", "Comments", "user" };
            int result = CsvInfo.GetColumnIndex(columnNames, "idontexist");
            int actual = -1;
            Assert.Equal(result, actual);
        }

        [Fact]
        public void GivenMultipleExistingColumnNamesReturnsThereIndexes()
        {
            string[] columnNames = new string[] { "ReviewDate", "Comments", "user" };
            int[] result = CsvInfo.GetColumnIndexes(columnNames, new string[]{ "user" , "ReviewDate" });
            int userIndex = 2;
            int reviewDateIndex = 0;
            Assert.Equal(result[0], userIndex);
            Assert.Equal(result[1], reviewDateIndex);
        }
    }
}
