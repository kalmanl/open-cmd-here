using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;      
using System.Windows;
using System.IO;
using System.Security.AccessControl;

namespace reg
{
    class Program
    {
        static string exefile = @"open_cmd_in_corrent_dir.exe";
        static string pathString = @"C:\\Users\\Public\\Documents\\DirCmd\\";
        public static void CopyFiles()
        {
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(pathString))
                {
                    Console.WriteLine("That path exists already.");
                }
                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(pathString);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(pathString));
                }

                string icofileToCopy = @"cmd.ico";
                //string destinationDirectory = "c:\\myDestinationFolder\\";

                //copy exe file and icon file
                File.Copy(exefile, pathString  + exefile, true);
                File.Copy(icofileToCopy, pathString + icofileToCopy, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process of copying the progran failed: {0}", e.ToString());
            }
        }

        public static void Reg()
        {
            try
            {
                RegistryKey key;

                key = Registry.ClassesRoot;

                key = key.OpenSubKey(@"Directory\Background\shell", true);

                key = key.CreateSubKey("open cmd here");

                key.SetValue("Icon", "\"" + pathString + "cmd.ico\"");

                key = key.CreateSubKey("command");

                key.SetValue("", "\"" + pathString + exefile + "\" \"=%v.\"");

                key.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process of setting reg values to the progran failed: {0}", e.ToString());
            }
        }

        static void Main(string[] args)
        {
            CopyFiles();
            Reg();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
