﻿namespace SkillFactory.Module_5
{
    class Task_5_5
    {
        public static void Main()
        {
            Console.WriteLine("Напишите что-то");
            var phrase = Console.ReadLine();

            Console.WriteLine("Укажите глубину эха");
            var deep = int.Parse(Console.ReadLine());

            Echo(phrase, deep);
            
            var factorial20 = Factorial(20);
            Console.WriteLine(factorial20);

            Console.ReadKey();
        }

        static void Echo(string saidworld, int deep)
        {
            var modif = saidworld;

            if (modif.Length > 2)
            {
                modif = modif.Remove(0, 2);
            }

            Console.BackgroundColor = (ConsoleColor)deep;
            Console.WriteLine("..." + modif);

            if (deep > 1)
            {
                Echo(modif, deep - 1);
            }
        }

        static decimal Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
        static int PowerUp(int N, byte pow)
        {
            if (pow == 0)
            {
                return 1;
            }
            else if (pow == 1)
            {
                return N;
            }
            else
            {
                pow -= 1;
                return N * PowerUp(N, pow);
            }
        }
    }
}
