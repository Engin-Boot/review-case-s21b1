using System;
using System.Collections.Generic;
using System.IO;


namespace Reciever
{
    //now writer takes the dict of words and make csv file

    public interface WriterCSV
    {
        void WriteToCSV(Dictionary<string, int> wordCount, string path);
        void ValidateOutputFileFormat(string filepath);
    }
    public class Writer : WriterCSV
    {
    
        public void ValidateOutputFileFormat(string filepath)
        {
            string fileExtension = filepath.Substring(filepath.LastIndexOf('.') + 1);
            if (!fileExtension.Equals("csv") && !fileExtension.Equals("xlsx"))
                throw new ArgumentException();

        }
        
        public void WriteToCSV(Dictionary<string, int> wordcount, string path)
        {
            //displose
            try
            {
                using (StreamWriter file = new StreamWriter(path, false))//true--append
                {
                    foreach (var word in wordcount)
                        file.WriteLine(word.Key + "," + word.Value);      //making csv

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException("FILE NOT COPIED", ex);
            }
        }
    }
}
