using System;
using Xunit;
using Reciever;
using System.Collections.Generic;
using System.IO;

namespace RecieverTest
{
    public class RecieverModuleTest
    {
        ConsoleReadAndMakeList _read = new ConsoleReadAndMakeList();
        WriterCSV _write = new Writer();
        string _fileName = "testing.csv";
        Dictionary<string, int> _wordTest = new Dictionary<string, int>()
        { {"wwe",2},{"realmad",3},{"fcb" ,4} };

        private static string GetPath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), fileName);
        }

        [Fact]
        public void WhenListOfLinesGivenThenReturnWordCount()
        {
            List<string> testList = new List<string> { "wwe", "fcb", "fcb", "wwe", "fcb", "fcb", "realmad", "realmad", "realmad" };
            Dictionary<string, int> testDict = MakeWordCount.ListToWordCount(testList);
            Assert.Equal(_wordTest["fcb"], testDict["fcb"]);
        }

        [Fact]
        public void WhenFileCorruptedThenThrowException()
        {
            Assert.Throws<ApplicationException>(() => FileCreater.GetDirectory(""));
        }

        [Fact]
        public void WhenFileStreamFailThenThrowsException()
        {
            Assert.Throws<ApplicationException>(() => _write.WriteToCSV(_wordTest, ""));
        }
        [Fact]
        public void WhenStopWordPresentThenSkipIt()
        {
            string word = "a";
            Assert.True(MakeWordCount.IsStopWordPresentOrNot.Invoke(word));
        }
        [Fact]
        public void WhenFileStreamSucceedsThenWriteOnFile()
        {
            _write.WriteToCSV(_wordTest, GetPath(_fileName));
            Assert.Equal("wwe,2", File.ReadAllLines(GetPath(_fileName))[0]);
        }
        [Fact]
        public void WhenFileArgumentIsAcceptedThenCreateNewFile()
        {
            FileCreater.GetDirectory(_fileName);
            Assert.True(File.Exists(GetPath(_fileName)));
            Assert.Equal(0, new FileInfo(GetPath(_fileName)).Length);
        }
        [Fact]
        public void WhenStopWordNotPresentThenDoNotSkipIt()
        {
            string word = "ign";
            Assert.False(MakeWordCount.IsStopWordPresentOrNot.Invoke(word));
        }


    }
}
