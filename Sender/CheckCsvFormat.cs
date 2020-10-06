using System;
using System.Collections.Generic;

namespace Sender
{
    public class CheckCsvFormat
    {
        public static bool CheckFormat(string path, IEnumerable<string> columnNames)
        {
            var columnsInFile = CsvInfo.GetColumns(path);
            if (columnsInFile == null)
            {
                return false;
            }
            var noOfColumns = columnsInFile.Length;
            foreach (var column in columnNames)
            {
                if (!Array.Exists(columnsInFile, element => element.Contains(column, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }
            }
            ICsvFileReader reader = new CsvFileReader();
            var lines = reader.Read(path);
            return IsNoOfColumnsSameInEachRow(lines, noOfColumns);
        }

        private static bool IsNoOfColumnsSameInEachRow(IEnumerable<string> lines, int numOfCol)
        {
            ICsvFileReader reader = new CsvFileReader();
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line) && reader.HandleQuotes(line).Split(',').Length != numOfCol)
                {
                    return false;
                }
            }
            return true;
        }
    }
}