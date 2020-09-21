using System;
using System.Collections.Generic;


namespace Reciever
{
    //1st take the console output and store in list 
    //every line 1 element
    public class ConsoleReadAndMakeList
    {
        public List<string> ReadConsole()
        {
            //1 line data comment
            string buffer;
            List<string> content = new List<string>();
            //read till end line
            char[] separator=new char[] { ' ' };
            while (!string.IsNullOrEmpty(buffer = Console.ReadLine()))
            {
                string[] temp = buffer.Split(separator, StringSplitOptions.RemoveEmptyEntries);  //data time comment
                if(temp.Length==3)
                    content.Add(temp[2]);               //take  comment else dont take it
            }
            return content;
        }

        //send to dictionary make word count
    }
}
