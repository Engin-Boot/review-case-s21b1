using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    public interface IConsoleWriter
    {
        void Write(string[] fileData, int timestampColumnIndex, int commentColumnIndex);
    }
    public class ConsoleWriter : IConsoleWriter
    {
        #region Deligates

        public Func<string, string[]> splitWithCommaFunc = line => line.Split(',');
        public Func<string, string[]> getSeriesOfWordsFunc = line => line.Split('?', ' ', ':', ';');

        #endregion

        public void Write(string[] fileData, int timestampColumnIndex, int commentColumnIndex)       // change string[] to ..
        {
            foreach (var line in fileData)
            {
                string[] row = GetRowFromLine(line, splitWithCommaFunc);
                string timestamp = row[timestampColumnIndex];
                string[] reviewWords = GetSeriesOfWords(row[commentColumnIndex], getSeriesOfWordsFunc);
                for (int i = 0; i < reviewWords.Length; i++)
                {
                    Console.WriteLine(timestamp+" "+reviewWords[i]);
                }

            }
            Console.WriteLine("END");
        }

        public string[] GetRowFromLine(string line, Func<string, string[]> splitFunc)
        {
            return splitFunc.Invoke(line);
        }

        public string[] GetSeriesOfWords(string line, Func<string, string[]> getSeriesOfWordsFunc)
        {
            return getSeriesOfWordsFunc.Invoke(line);
        }
    }
}
