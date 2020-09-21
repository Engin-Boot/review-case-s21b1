using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciever
{
    //now writer takes the dict of words and make csv file

    public interface WriterCSV
    {
        void WriteToCSV(Dictionary<string, int> wordCount, string path);
    }
    public class Writer : WriterCSV
    {
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
