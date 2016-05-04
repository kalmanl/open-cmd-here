using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows;
using System.IO;
using System.Security.AccessControl;


namespace reg_uninstall
{
    class Program
    {
        public static void DelFiles()
        {
            try
            {
                string pathString = @"C:\\Users\\Public\\Documents\\DirCmd";

                Directory.Delete(pathString, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error deleting files: {0}", e.ToString());
            }
        }
        public static void DelReg()
        {
            try
            {
                RegistryKey key;

                key = Registry.ClassesRoot;

                key = key.OpenSubKey(@"Directory\Background\shell\", true);

                key.DeleteSubKeyTree("open cmd here");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error deleting reg entry: {0}", e.ToString());
            }
        }

        static void Main(string[] args)
        {
            DelFiles();
            DelReg();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
