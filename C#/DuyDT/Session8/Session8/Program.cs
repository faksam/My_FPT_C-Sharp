using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Session8
{
    class Program
    {
        static void ListAllFiles(string dir)
        {
            //get all files at current dir
            string[] files = Directory.GetFiles(dir);
            foreach (string f in files)
                Console.WriteLine(f);
            //get all sub directories at current dir
            string[] subdirs = Directory.GetDirectories(dir);
            foreach (string sd in subdirs)
                ListAllFiles(sd);
        }
        static void Main(string[] args)
        {
            string dir = "./";
            //watching dir
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = dir;
            //raise events
            fsw.Deleted += new FileSystemEventHandler(fsw_Deleted);
            fsw.Renamed += new RenamedEventHandler(fsw_Renamed);
            fsw.Created += new FileSystemEventHandler(fsw_Created);
            fsw.EnableRaisingEvents = true;
            Console.WriteLine("Now start watching {0} folder",dir);
            Console.WriteLine("Press any key to stop...");
            Console.ReadLine();
        }

        static void fsw_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File named {0} has been created",e.Name);
        }

        static void fsw_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("File name changed from {0} to {1}",e.OldName
                ,e.Name);
        }

        static void fsw_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Deleted file named {0}",e.Name);
        }
    }
}
