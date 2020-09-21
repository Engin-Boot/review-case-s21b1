using System;
using Xunit;
using System.Diagnostics;
using Reciever;
using System.Collections.Generic;
using System.IO;

namespace RecieverTest
{
    public class RecieverModuleTest
    {
        ConsoleReadAndMakeList _read = new ConsoleReadAndMakeList();
        Writer _write = new Writer();
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
            List<string> testList = new List<string> { "wwe", "world", "health", "wwe", "fcb", "fcb", "realmad", "psg", "realmad" };
            Dictionary<string, int> testDict = MakeWordCount.ListToWordCount(testList);
            Assert.Equal(_wordTest["wwe"], testDict["wwe"]);
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
        public void WhenStopWordPresentThenShowit()
        {
            string word = "a";
            Assert.True(StopWords.IsStopWordPresentOrNot(word));
        }
        [Fact]
        public void WhenFileStreamSucceedsThenWriteOnFile()
        {
            _write.WriteToCSV(_wordTest, GetPath(_fileName));
            Assert.Equal("wwe,2", File.ReadAllLines(GetPath(_fileName))[0]);
        }



    }
}
