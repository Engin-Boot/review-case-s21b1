using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciever
{
    class Recieve
    {
        static void Main(string[] args)
        {
            //we need to take cosole data and send to make file and do the word count
            ConsoleReadAndMakeList read = new ConsoleReadAndMakeList();
            Writer write = new Writer();
            Dictionary<string, int> wordCount = MakeWordCount.ListToWordCount(read.ReadConsole());
            Console.WriteLine(Directory.GetCurrentDirectory());
            string pathlocation = FileCreater.GetDirectory("file.csv");
            //Dictionary<string, int> wordCount = new Dictionary<string, int>() { { "wwe", 2 }, { "qqq", 3 }, { "rrr", 1 } };
            write.WriteToCSV(wordCount, pathlocation);
        }
    }
}
