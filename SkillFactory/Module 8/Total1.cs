using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Module_8
{
    internal class Total1
    {
        public static void Main()
        {
            string DirName = "E:\\temp";
            Cleaner(DirName);
        }
        public static void Cleaner(string dirName)
        {
            try
            {
                DirectoryInfo dirInfo = new(dirName);
                if (dirInfo.Exists)
                {
                    FileInfo[] fileNames = dirInfo.GetFiles();
                    foreach (var file in fileNames)
                    {
                        if (file.LastAccessTime.CompareTo(DateTime.Now - TimeSpan.FromMinutes(30)) < 0)
                        {
                            file.Delete();
                        }
                    }
                    DirectoryInfo[] folderNames = dirInfo.GetDirectories();
                    foreach (var folder in folderNames)
                    {
                        Cleaner(folder.FullName);
                        if (folder.LastAccessTime.CompareTo(DateTime.Now - TimeSpan.FromMinutes(30)) < 0)
                        {
                            folder.Delete(true);
                        }
                    }

                    Console.WriteLine($"Очистка папки {dirInfo.FullName} от файлов и папок, не использующихся более 30 минут завершена");
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

        }
    }
}
