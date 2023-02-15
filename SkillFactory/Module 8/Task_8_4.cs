using System;
using System.IO;
 
namespace SkillFactory.Module_8
{
    class Taks_8_4
    {
        public static void Main()
        {
            Taks_8_4_1();
            Taks_8_4_2();
        }
        public static void Taks_8_4_1()
        {
            string path = "E:\\Work\\SkillFactory\\SkillFactory\\Module 8\\BinaryFile.bin";

            if (File.Exists(path))
            {
                string fileData;
                using (BinaryReader reader = new(File.Open(path, FileMode.Open)))
                {
                    fileData = reader.ReadString();
                }
                Console.WriteLine("Данные из файла: ");
                Console.WriteLine(fileData);
            } else
            {
                Console.WriteLine("Файл не обнаружен");
            }
        }
        public static void Taks_8_4_2()
        {
            string path = "E:\\Work\\SkillFactory\\SkillFactory\\Module 8\\BinaryFile2.bin";
            // Write values
            using BinaryWriter writer = new(File.Open(path, FileMode.Open)); writer.Write($"Файл изменен {DateTime.Now} на ОС {Environment.OSVersion}");

            // Read Values
            if (File.Exists(path))
            {
                using (BinaryReader reader = new(File.Open(path, FileMode.Open)))
                {
                    Console.WriteLine(reader.ReadString());
                }
            }
        }
    }
}