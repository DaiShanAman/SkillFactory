using System;

namespace Module_19_Social_Network.BLL.Exceptions
{
    public class ShortPasswordException : Exception
    {
        public ShortPasswordException () ///(string message) : base(message)
        {
            Console.WriteLine($"Ошибка: пароль должен содержать 8 и более символов");
        }
    }
}
