using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    public class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\a\review-case-s21b1\review-case-s21b11\Sample1.csv";
            if (!PathChecker.DoesPathExists(path))
            {
                Console.WriteLine("Provide a Existing path");
                System.Environment.Exit(1);
            }

            ICsvFileReader fileReader = new CsvFileReader();
            
            string[] rows = fileReader.Read(path,new string[] { "ReviewDate","Comments" });
            rows = fileReader.SkipHeader(rows);
            IConsoleWriter consoleWriter = new ConsoleWriter();
            string[] dataToprintOnConsole = consoleWriter.GetDataInWritableFormat(rows,0,1);
            consoleWriter.WriteToConsole(dataToprintOnConsole);


        }
    }
}
