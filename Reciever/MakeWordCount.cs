using System;
using System.Collections.Generic;


namespace Reciever
{
    public class MakeWordCount
    {
        public static Func<string, bool> IsStopWordPresentOrNot = (string word) =>
        {
            List<string> stopwordlist = new List<string>() { "a", "able", "about", "across", "after", "all", "almost", "also", "am", "among", "an", "and", "any",
                    "are","as", "at", "be", "because", "been", "but", "by", "can", "cannot", "could", "dear", "did","do","does","either","else","ever","every","for",
                    "from", "get", "got", "had" };
            //make stopword list 

            return (stopwordlist.Contains(word));
        };
        public static Dictionary<string, int> ListToWordCount(List<string> wordlist)
        {
            //take list and make dict 
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (string word in wordlist)
            {

                if (!IsStopWordPresentOrNot.Invoke(word))
                {
                    if (wordCount.ContainsKey(word))
                        wordCount[word]++;
                    else
                        wordCount[word] = 1;
                };

            }
            return wordCount;
        }
    }
}
