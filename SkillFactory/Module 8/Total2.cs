using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Module_8
{
    internal class Total2
    {
        public static void Main()
        {
            string DirName = "E:\\temp";
            Console.WriteLine($"Размер папки {DirName} - {ShowFolderSize(DirName)} байт.");
        }
        public static long ShowFolderSize(string dirName)
        {
            long folderSize = 0;
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                if (dirInfo.Exists)
                {
                    FileInfo[] files = dirInfo.GetFiles();
                    foreach (var item in files)
                    {
                        folderSize += item.Length;
                    }
                    DirectoryInfo[] subfolders = dirInfo.GetDirectories();
                    foreach (var item in subfolders)
                    {
                        folderSize += ShowFolderSize(item.FullName);
                    }
                }
                else
                {
                    Console.WriteLine("Нет такой директории");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return folderSize;
        }
    }
}