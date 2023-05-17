namespace Module_15
{
    class Program
    {
        static void Main(string[] args)
        {
            var classes = new[]
            {
                new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
                new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
                new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
            };
            var allStudents = GetAllStudents(classes);

            Console.WriteLine(string.Join(" ", allStudents));
        }

        static string[] GetAllStudents(Classroom[] classes)
        {
            // Как то просто для итога двух больших модулей по офигенно важной теме без которой ни один проект ни живет... 
            string[] allStudents = classes.SelectMany(c => c.Students).ToArray();

            return allStudents;
        }
    }
}