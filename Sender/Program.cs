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
            var path = @"D:\a\ReviewOfReviews-S21B1\ReviewOfReviews-S21B1\Sample1.csv";
            if (!PathChecker.DoesPathExists(path))
            {
                Console.WriteLine("Provide a Existing path");
                System.Environment.Exit(1);
            }

            ICsvFileReader fileReader = new CsvFileReader();
            
            string[] rows = fileReader.Read(path,new string[] { "ReviewDate","Comments" });
            rows = fileReader.SkipHeader(rows);
            IConsoleWriter consoleWriter = new ConsoleWriter();
            consoleWriter.Write(rows,0,1);


        }
    }
}
