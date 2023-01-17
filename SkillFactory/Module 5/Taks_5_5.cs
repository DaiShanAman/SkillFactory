namespace SkillFactory.Module_5
{
    class Taks_5_5
    {
        public static void Main()
        {
            Console.WriteLine("Напишите что-то");
            var phrase = Console.ReadLine();

            Console.WriteLine("Укажите глубину эха");
            var deep = int.Parse(Console.ReadLine());

            Echo(phrase, deep);

            Console.ReadKey();
        }

        static void Echo(string saidworld, int deep)
        {
            var modif = saidworld;

            if (modif.Length > 2)
            {
                modif = modif.Remove(0, 2);
            }

            Console.WriteLine("..." + modif);

            if (deep > 1)
            {
                Echo(modif, deep - 1);
            }
        }
    }
}
