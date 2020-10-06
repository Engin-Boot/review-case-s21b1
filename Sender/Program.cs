using System;
using System.Diagnostics.CodeAnalysis;

namespace Sender
{
    public class Program
    {
        [ExcludeFromCodeCoverage]
        static void Main()
        {
            var path = @"D:\a\review-case-s21b1\review-case-s21b11\Sample1.csv";
            //var path = "C:/Users/Ajay kumar/Desktop/Sample2.csv";
            if (!PathChecker.DoesPathExists(path))
            {
                Console.WriteLine("Provide a Existing path");
                System.Environment.Exit(1);
            }
            if (!CheckCsvFormat.CheckFormat(path, new string[] { "ReviewDate", "Comments" }))
            {
                Console.WriteLine("File is not in required format");
                System.Environment.Exit(1);
            }
            ICsvFileReader fileReader = new CsvFileReader();
            
            string[] rows = fileReader.Read(path,new string[] { "ReviewDate","Comments" });
            rows = fileReader.SkipHeader(rows);
            IConsoleWriter consoleWriter = new ConsoleWriter();
            string[] dataToPrintOnConsole = consoleWriter.GetDataInWritableFormat(rows,0,1);
            consoleWriter.WriteToConsole(dataToPrintOnConsole);


        }
    }
}
