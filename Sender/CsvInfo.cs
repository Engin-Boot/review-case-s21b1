using System;
using System.IO;


namespace Sender
{
    public class CsvInfo
    {
        public static string[] GetColumns(string filePath)
        {
            //if (!PathChecker.DoesPathExists(filePath))
            //{
            //    throw new Exception("File doesn't Exist");
            //}

            var sr = File.OpenText(filePath);
            string[] columns = null;
            var firstLine = sr.ReadLine();
            if (!string.IsNullOrEmpty(firstLine))
            {
                columns = firstLine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            return columns;
        }

        public static int GetColumnIndex(string[] columns, string columnName)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i].Contains(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }

        public static int[] GetColumnIndexes(string[] columnNames, string[] requiredColumns)
        {
            int[] requiredColumnIndexes = new int[requiredColumns.Length];
            for (int i = 0; i < requiredColumns.Length; i++)
            {
                requiredColumnIndexes[i] = CsvInfo.GetColumnIndex(columnNames, requiredColumns[i]);
            }

            return requiredColumnIndexes;
        }
    }
}
