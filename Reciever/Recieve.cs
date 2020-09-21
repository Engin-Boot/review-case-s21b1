using System;
using System.Collections.Generic;
using System.IO;

namespace Reciever
{
    class Recieve
    {
        
        static void Main(string[] args)
        {
            //we need to take cosole data and send to make file and do the word count
            ConsoleReadAndMakeList read = new ConsoleReadAndMakeList();
            WriterCSV write = new Writer(); 
            Dictionary<string, int> wordCount = MakeWordCount.ListToWordCount(read.ReadConsole());
            string filePath="file.csv";
            write.ValidateOutputFileFormat(filePath);
            Console.WriteLine(Directory.GetCurrentDirectory());
            string pathlocation = FileCreater.GetDirectory(filePath);
            
            write.WriteToCSV(wordCount, pathlocation);
        }
    }
}
