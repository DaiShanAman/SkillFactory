namespace Module_13
{
    internal class Task2
    {
        public static void Reader()
        {
            // Загрузка текстового файла
            string textFilePath = "Text1.txt";
            string text = File.ReadAllText(textFilePath);

            // Удаление знаков пунктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            // Разделение текста на слова
            string[] words = noPunctuationText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Подсчет количества повторений каждого слова
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            // Нахождение 10 самых часто встречающихся слов
            var topWords = wordCount.OrderByDescending(pair => pair.Value).Take(10);

            // Вывод результатов
            Console.WriteLine("10 самых частых слов в тексте:");
            foreach (var pair in topWords)
            {
                Console.WriteLine($"Слово \"{pair.Key}\": {pair.Value} раз");
            }
        }
    }
}
