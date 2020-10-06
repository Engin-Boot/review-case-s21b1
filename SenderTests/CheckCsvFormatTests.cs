using Sender;
using Xunit;

namespace SenderTests
{
    public class CheckCsvFormatTests
    {
        [Fact]
        public void IfFirstLineInFileIsEmptyReturnFalse()
        {
            var path = @"D:/a/review-case-s21b1/review-case-s21b1/Sample5.csv";
            var actual = CheckCsvFormat.CheckFormat(path, new string[] { "ReviewDate", "Comments" });
            var expected = false;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GivenACorrectFormatFileReturnsTrue()
        {
            var path = @"D:/a/review-case-s21b1/review-case-s21b1/Sample3.csv";
            var actual = CheckCsvFormat.CheckFormat(path, new string[] { "ReviewDate", "Comments" });
            var expected = true;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenWrongColumnNamesReturnsFalse()
        {
            var path = @"D:/a/review-case-s21b1/review-case-s21b1/Sample3.csv";
            var actual = CheckCsvFormat.CheckFormat(path, new string[] { "ReviewDate", "Comments", "Age" });
            var expected = false;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IfRowsHavingDifferentColumnSizeReturnFalse()
        {
            var path = @"D:/a/review-case-s21b1/review-case-s21b1/Sample4.csv";
            var actual = CheckCsvFormat.CheckFormat(path, new string[] { "ReviewDate", "Comments", "user" });
            var expected = false;
            Assert.Equal(expected, actual);
        }
    }
}