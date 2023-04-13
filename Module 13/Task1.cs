using System.Diagnostics;
using System.IO;

namespace Module_13
{
    internal class Task1
    {
        public static void Сomparator()
        {
            // Загрузка текстового файла
            // у меня он из бина грузится почему-то, а не относительно этого файла, сразу отмечу, не понимаю почему
            string textFilePath = "Text1.txt";
            List<string> lines = new List<string>();

            using (StreamReader reader = new(textFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            


            // Создание List<T>
            List<string> list = new();
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Вставка в List<T>
            foreach (string line in lines)
            {
                list.Add(line);
            }

            stopwatch.Stop();
            Console.WriteLine($"Время вставки List<T>: {stopwatch.Elapsed}");



            // Создание LinkedList<T>
            LinkedList<string> linkedList = new LinkedList<string>();
            stopwatch = Stopwatch.StartNew();

            // Вставка в LinkedList<T>
            foreach (string line in lines)
            {
                linkedList.AddLast(line);
            }

            stopwatch.Stop();
            Console.WriteLine($"Время вставки LinkedList<T>: {stopwatch.Elapsed}");
        }
    }
}
