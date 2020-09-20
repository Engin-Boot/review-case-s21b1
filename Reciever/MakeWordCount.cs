using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciever
{
    public class MakeWordCount
    {
        public static Dictionary<string, int> ListToWordCount(List<string> wordlist)
        {
            //take list and make dict 
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (string word in wordlist)
            {

                if (!StopWords.IsStopWordPresentOrNot(word))
                {
                    if (wordCount.ContainsKey(word))
                        wordCount[word]++;
                    else
                        wordCount[word] = 1;
                }

            }
            return wordCount;
        }
    }
}
