using System;
using System.IO;


namespace Reciever
{
    //get the directory path
    public class FileCreater
    {
        public static string GetDirectory(string path)
        {
            string currentDirectory = Directory.GetCurrentDirectory();//default bin/debug/
            string fileLocation = Path.Combine(currentDirectory, path);

            try
            {

                File.Create(fileLocation).Close();
                Console.WriteLine("FILE CREATED");
            }
            catch (Exception ex)
            {
                Console.WriteLine("NO FILE NOT CREATED");
                throw new ApplicationException();
            }
            return fileLocation;
        }
    }
}
