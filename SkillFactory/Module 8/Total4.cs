using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    class Program
    {
        public static void Main()
        {
            CreateFolder();
            СreateFile();
        }
        public static void СreateFile()
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathSourseFile = Path.Combine(path, @"Students.dat");

            try
            {
                BinaryFormatter formatter = new ();
                Student[] students =
                {
                    new Student("Вася", "Группа1", new DateTime(2002, 11, 23)),
                    new Student("Гриша", "Группа2", new DateTime(2002, 6, 20)),
                    new Student("Света", "Группа1", new DateTime(2001, 4, 13)),
                    new Student("Паша", "Группа3", new DateTime(2003, 12, 5)),
                    new Student("Кирилл", "Группа1", new DateTime(2004, 3, 3)),
                    new Student("Ваня", "Группа2", new DateTime(2003, 5, 13)),
                    new Student("Вова", "Группа1", new DateTime(2002, 6, 30)),
                    new Student("Евгений", "Группа1", new DateTime(2001, 2, 12)),
                    new Student("Жора", "Группа1", new DateTime(2002, 1, 26)),
                };
                // сериализация
                using (var fs = new FileStream(pathSourseFile, FileMode.OpenOrCreate))
                {
                    foreach (Student student in students)
                    {
                        formatter.Serialize(fs, students);
                    }
                    Console.WriteLine("Создан фаил Students.dat и записаны студенты ");
                }


                // десериализация
                using (var fs = new FileStream(pathSourseFile, FileMode.Open))
                {

                    using StreamWriter sw = new StreamWriter(Path.Combine(path, @"Students/Group1.txt"));
                    foreach (Student student in students)
                    {
                        if (student.Group == "Группа1")
                            sw.WriteLine($"Имя: {student.Name} Дата рождения: {student.DateOfBirth} ");
                    }
                    Console.WriteLine("Cписок Группы 1 создан");

                    using StreamWriter sR = new StreamWriter(Path.Combine(path, @"Students/Group2.txt"));
                    foreach (Student student in students)
                    {
                        if (student.Group == "Группа2")
                            sR.WriteLine($"Имя: {student.Name} Дата рождения: {student.DateOfBirth} ");
                    }
                    Console.WriteLine("Cписок Группы 2 создан");
                    using StreamWriter sF = new StreamWriter(Path.Combine(path, @"Students/Group3.txt"));
                    foreach (Student student in students)
                    {
                        if (student.Group == "Группа3")
                            sF.WriteLine($"Имя: {student.Name} Дата рождения: {student.DateOfBirth} ");
                    }
                    Console.WriteLine("Cписок Группы 3 создан");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void CreateFolder()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathSourseFile = Path.Combine(path, @"Students");

            try
            {
                DirectoryInfo newDirectory = new DirectoryInfo(pathSourseFile);
                if (!newDirectory.Exists)
                    newDirectory.Create();
                Console.WriteLine("Папка создана.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }
}