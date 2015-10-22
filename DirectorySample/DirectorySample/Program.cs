using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DirectorySample
{
    class Program
    {
        static void Main(string[] args)
        {
            //specify the name of directory that you want to make new
            string dirName = "D:\\Test";
            dirName = "E:/Test";
            dirName = @"E:\Test";
            //if dirName exist already
            if(Directory.Exists(dirName)==true)
            {
                //remove dirName, true = remove all items under dirname
                Directory.Delete(dirName, true);
            }
            //make new directory name dirName
            Directory.CreateDirectory(dirName);
            Console.WriteLine("Directory{0} has been created",dirName);
            //use DirectoryInfo
            DirectoryInfo di = new DirectoryInfo(dirName);

            Console.WriteLine("Root of directory: {0}",
               di.Root);//D
            Console.WriteLine("CreateTime: {0}",
               di.CreationTime);//08:17
            Console.WriteLine("Parent: {0}",
                di.Parent);



            /* 
            //read and print information of dirname
          Console.WriteLine("Root of directory: {0}",
                Directory.GetDirectoryRoot(dirName));//D
            Console.WriteLine("CreateTime: {0}",
                Directory.GetCreationTime(dirName));//08:17
            Console.WriteLine("Parent: {0}",
                Directory.GetParent(dirName));*/

            Console.WriteLine("press any key to remove...");
            Console.ReadLine();
            Directory.Delete(dirName, true);

        }
    }
}
