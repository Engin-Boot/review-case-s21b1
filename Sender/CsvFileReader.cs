using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    public interface ICsvFileReader
    {
        string[] Read(string filePath, string[] requiredColumns);
        string[] SkipHeader(string[] array);
    }
    public class CsvFileReader : ICsvFileReader
    {
        public string[] Read(string path)
        {
            return File.ReadAllLines(path);
        }

        private Func<int[], string, string> columnFilterFunc = (columnIndexes, line) =>
        {
            string filteredLine = "";
            string[] row = line.Split(',');
            for (int i = 0; i < columnIndexes.Length; i++)
            {
                filteredLine += row[columnIndexes[i]];
                filteredLine += ",";
            }
            return filteredLine.Remove(filteredLine.Length-1,1);
        };
        public string[] Read(string filePath, string[] requiredColumns)
        {
            #region Variables
            List<string> fileData = new List<string>();
            string[] columnNames = CsvInfo.GetColumns(filePath);
            int[] requiredColumnIndexes = CsvInfo.GetColumnIndexes(columnNames, requiredColumns);
            #endregion

            using (StreamReader csvReader = File.OpenText(filePath))
            {
                var line = "";
                while ((line = csvReader.ReadLine()) != null)
                {
                    line = HandleQuotes(line);
                    line = Filter(columnFilterFunc, requiredColumnIndexes, line);
                    fileData.Add(line);
                }
            }

            return fileData.ToArray();
        }

        public string HandleQuotes(string line)
        {
            return line;               // implement quote handling
        }

        public string Filter(Func<int[],string,string > columnFilterFunc ,int[] requiredColumnIndexes, string line)
        {
            return columnFilterFunc.Invoke(requiredColumnIndexes, line);
        }

        public string[] SkipHeader(string[] array)
        {
            return array.Skip(1).ToArray();
        }
    }
}
