using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciever
{
    public class StopWords
    {
        public static bool IsStopWordPresentOrNot(string word)
        {
            List<string> stopwordlist = new List<string>() { "a", "able", "about", "across", "after", "all", "almost", "also", "am", "among", "an", "and", "any",
                    "are","as", "at", "be", "because", "been", "but", "by", "can", "cannot", "could", "dear", "did","do","does","either","else","ever","every","for",
                    "from", "get", "got", "had" };
            //make stopword list 

            return (stopwordlist.Contains(word));
        }
    }
}
