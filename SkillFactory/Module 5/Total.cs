namespace SkillFactory.Module_5
{
    internal class Total
    {
        public static void Main()
        {
            ShowUser(createUser());
        }
        static void ShowUser ((string name, string surname, byte age, string[]? petsName, string[] favColors) user)
        {
            Console.WriteLine("\nИнофрмация о пользователе:");
            Console.WriteLine($"Имя: {user.name}");
            Console.WriteLine($"Фамилия: {user.surname}");
            Console.WriteLine($"Возраст: {user.age}");

            

            if (user.petsName != null)
            {
                Console.WriteLine($"Количество питомцев: {user.petsName.Length}");
                Console.WriteLine("Имена питомцев: ");

                ShowArray(user.petsName);
            }

            if (user.favColors != null)
            {
                Console.WriteLine($"Количество любимых цветов: {user.favColors.Length}");
                Console.WriteLine("Цвета: ");

                ShowArray(user.favColors);
            }
        }

        static (string name, string surname, byte age, string[]? petsName, string[] favColors) createUser()
        {
            (string name, string surname, byte age, bool havePet, int amountPet, string[]? petsName, int amountFavColors, string[] favColors) user;

            do
            {
                Console.WriteLine("\nВведите имя");

            } while (!CheckNameSurname(Console.ReadLine(), out user.name));


            do
            {
                Console.WriteLine("\nВведите фамилию");
            } while (!CheckNameSurname(Console.ReadLine(), out user.surname));


            int correctAge;
            do
            {
                Console.WriteLine("\nВведите возраст");

            } while (!CheckNumber(Console.ReadLine(), out correctAge));
            user.age = (byte)correctAge;


            Console.WriteLine("\nУ вас есть питомцы? \nВведите Да или Нет");
            user.havePet = Console.ReadLine().ToLower() == "да" ? true : false;
            


            int correctAmount;
            user.petsName = null;
            if (user.havePet)
            {
                do
                {
                    Console.WriteLine("\nВведите количество питомцев");
                } while (!CheckNumber(Console.ReadLine(), out correctAmount));

                user.petsName = CreateArray(correctAmount, "pets");
            }
            else
            {
                Console.WriteLine("\nНу у вас либо нет питомцев, либо вы ввели что-то не так...");
            }



            do
            {
               Console.WriteLine("\nВведите количество любимых цветов");
            } while (!CheckNumber(Console.ReadLine(), out correctAmount));

                user.favColors = CreateArray(correctAmount, "colors");

            return (user.name, user.surname, user.age, user.petsName, user.favColors); ;
        }
        
        static string[] CreateArray(int amount, string type)
        {
            string[] array = new string[amount];

            for (int i = 0; i < array.Length; i++)
            {
                if (type == "pets")
                {
                    Console.WriteLine("\nВведите имя питомца");
                    array[i] = Console.ReadLine() ?? "Нет имени";
                } else if (type == "colors")
                {
                    Console.WriteLine("\nВведите цвет");
                    array[i] = Console.ReadLine() ?? "Нет цвета";
                }
            }

            return array;
        }

        static bool CheckNameSurname(string name, out string correctName)
        {
            
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Эта строка не может быть пустой! Попробуйте снова");
                correctName = string.Empty;
                return false;
            }
            else if (int.TryParse(name, out int result))
            {
                Console.WriteLine("В этой строке не может быть чисел! Попробуйте снова");
                correctName = string.Empty;
                return false;
            } else
            {
                correctName = name;
                return true;
            }

            Console.WriteLine("Некорректное имя или фамилия!");
            correctName = string.Empty;
            return false;
        }

        static bool CheckNumber(string number, out int correctNumber)
        {
            if (int.TryParse(number, out int intNumber))
            {
                if (intNumber > 0 && intNumber < 100)
                {
                    correctNumber = intNumber;
                    return true;
                }
            }

            Console.WriteLine("Некорректное число");
            correctNumber = default;
            return false;
        }

        static void ShowArray(string[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
