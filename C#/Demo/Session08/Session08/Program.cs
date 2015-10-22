using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Session08
{
    class Program
    {
        static void ListAllFiles(string dir)
        {
            //list all files of current dir
            string[] files = Directory.GetFiles(dir);
            foreach (string f in files)
                Console.WriteLine(f);
            //list all sub directories of current dir
            string[] fdirs = Directory.GetDirectories(dir);
            foreach (string d in fdirs)
                ListAllFiles(d);
        }
        static void Main(string[] args)
        {/*
            //reference to C:\data
            string dir = @"C:\data";
            dir = "C:/data";
            DirectoryInfo di = new DirectoryInfo(dir);

            //if dir is exist
            if (di.Exists)
            {
                Console.WriteLine("Full name: " + di.FullName);
                Console.WriteLine("Creative Time: " + di.CreationTime);
                //list all files of di
                ListAllFiles(dir);
            }
            else
            {
                Console.WriteLine("The directory {0} does not exists", dir);
            }*/


            /*todo list
             * 1. Enter a file name
             * 2.
             * *
            string fname = "";
            Console.WriteLine("Enter a file name");
            fname = Console.ReadLine();
            if (!File.Exists(fname))
            {
                StreamWriter sw = File.CreateText(fname);
                sw.WriteLine("New file has been created");
                sw.WriteLine(sw.NewLine);
                for (int i = 1; i <= 5; i++)
                    sw.WriteLine(i);
                sw.Close();
            }
            else
            {
                Console.WriteLine("Sorry, {0} exists already", fname );
                Console.WriteLine("Press anykey to view content of file");
                Console.ReadLine();
                StreamReader sr = File.OpenText(fname);
                string line = "";
                while ((line = sr.ReadLine()) != null)
                    Console.WriteLine(line);
                sr.Close();
            }*/
            /*
            string fname = "data.txt";
            StreamWriter bw = new StreamWriter(fname);
            char[] c={'A','B', 'C'};
            int i = 10;
            bw.Write(i);
            bw.Write(c);
            bw.Close();
            Console.WriteLine("Press anykey to continue...");
            //read file
            StreamReader sr = new StreamReader(fname);
            while((i = sr.Read())!= -1)
                Console.WriteLine(i);
            sr.Close();
            */

            string dir = "./";
            FileSystemWatcher sfw = new FileSystemWatcher(dir);
            sfw.Renamed += new RenamedEventHandler(sfw_Renamed);
            sfw.Created += new FileSystemEventHandler(sfw_Created);
            sfw.Deleted += new FileSystemEventHandler(sfw_Deleted);
            sfw.EnableRaisingEvents = true;
            Console.WriteLine("Now watching folder named {0} ", dir);
            Console.WriteLine("Press anykey to stop");
            Console.ReadLine();

        }

        static void sfw_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Deleted file name {0}", e.Name);
        }

        static void sfw_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("New file name {0} has been created", e.Name);
        }

        static void sfw_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("Name change from {0} to {1}", e.OldName, e.Name);
        }
    }
}
