using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Module_8
{
    internal class Total3
    {
        public static void Main()
        {
            string DirName = @"D:\new";
            Console.WriteLine($"Исходный размер папки {DirName} - {Total2.ShowFolderSize(DirName)} байт.");
            Total1.Cleaner(DirName);
            Console.WriteLine($"Текущий размер папки {DirName} - {Total2.ShowFolderSize(DirName)} байт.");
        }
        
    }
}