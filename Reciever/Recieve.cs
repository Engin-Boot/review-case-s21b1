using System;
using System.Collections.Generic;
using System.IO;

namespace Reciever
{
    class Recieve
    {
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            //we need to take cosole data and send to make file and do the word count
            ConsoleReadAndMakeList read = new ConsoleReadAndMakeList();
            WriterCSV write = new Writer(); 
            Dictionary<string, int> wordCount = MakeWordCount.ListToWordCount(read.ReadConsole());
            write.ValidateOutputFileFormat(filePath);
            Console.WriteLine(Directory.GetCurrentDirectory());
            string pathlocation = FileCreater.GetDirectory("file.csv");
            
            write.WriteToCSV(wordCount, pathlocation);
        }
    }
}
