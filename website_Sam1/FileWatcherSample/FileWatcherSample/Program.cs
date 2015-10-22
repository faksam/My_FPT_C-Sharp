using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileWatcherSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the Name of the folder that will  be watched
            string dir = @"E:\Data";
            // set up a camera for dir
            FileSystemWatcher fsw = new FileSystemWatcher(dir);
            // What kind of action the camera will catch
            fsw.Created += new FileSystemEventHandler(fsw_Created);
            fsw.Deleted += new FileSystemEventHandler(fsw_Deleted);
            fsw.Changed += new FileSystemEventHandler(fsw_Changed);
            fsw.Renamed += new RenamedEventHandler(fsw_Renamed);
            // now to start watching
            fsw.EnableRaisingEvents = true;
            Console.WriteLine("Now Watching folder {0} ",dir);
            Console.Write("Press any key to stop....");
            Console.Read();
        }

        static void fsw_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("The item {0} has been Renamed from {0} to {1}.",e.OldFullPath, e.Name);
        }

        static void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("The item {0} has been changed.", e.Name);
        }

        static void fsw_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("The item {0} has been removed.", e.Name);
        }

        static void fsw_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("The item {0} has been created.",e.Name);
        }
    }
}
