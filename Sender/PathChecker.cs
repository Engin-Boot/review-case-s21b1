using System;
using System.IO;

namespace Sender
{
    public class PathChecker
    {
        public static bool DoesPathExists(string path)
        {
            if (File.Exists(path))
                return true;
            Console.WriteLine("Given File Path doesn't Exist");
            return false;
        }
    }
}
