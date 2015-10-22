using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace FileWatcherSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //specify the name of folder that will be watched
            string dir = @"E:\data";
            //setup "camera" for dir
            FileSystemWatcher fsw = new FileSystemWatcher(dir);
            //create new item insde dir
            fsw.Created += fsw_Created;
            fsw.Deleted += fsw_Deleted;
            fsw.Changed += fsw_Changed;
            fsw.Renamed += fsw_Renamed;
            //now start watching
            Console.WriteLine("now Watching folder {0} ", dir);
            Console.WriteLine("press any key to stop");
            Console.ReadLine();

        }

        static void fsw_Renamed(object sender, RenamedEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void fsw_Deleted(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void fsw_Created(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
