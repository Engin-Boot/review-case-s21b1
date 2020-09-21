using System;
using System.Collections.Generic;


namespace Sender
{
    public interface IConsoleWriter
    {
        string[] GetDataInWritableFormat(string[] fileData, int timestampColumnIndex, int commentColumnIndex);
        void WriteToConsole(string[] lines);
    }
    public class ConsoleWriter : IConsoleWriter
    {
        #region Deligates

        public Func<string, string[]> splitWithCommaFunc = line => line.Split(',');
        public Func<string, string[]> getSeriesOfWordsFunc = line => line.Split('?', ' ', ':', ';');

        #endregion

        public string[] GetDataInWritableFormat(string[] fileData, int timestampColumnIndex, int commentColumnIndex)       // change string[] to ..
        {
            List<string> data = new List<string>();
            foreach (var line in fileData)
            {
                string[] row = GetRowFromLine(line, splitWithCommaFunc);
                string timestamp = row[timestampColumnIndex];
                string[] reviewWords = GetSeriesOfWords(row[commentColumnIndex], getSeriesOfWordsFunc);
                for (int i = 0; i < reviewWords.Length; i++)
                {
                    //Console.WriteLine(timestamp+" "+reviewWords[i]);
                    data.Add(timestamp + " " + reviewWords[i]);
                }

            }

            return data.ToArray();
            //Console.WriteLine("END");
        }

        public void WriteToConsole(string[] lines) 
        {  foreach (var line in lines)
                Console.WriteLine(line); }

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
