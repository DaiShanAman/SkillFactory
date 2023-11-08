using System;

namespace Module_19_Social_Network.BLL.Exceptions
{
    public class EmailValidException : Exception
    {
        public EmailValidException (string message) : base(message)
        {
            Console.WriteLine($"Ошибка: адрес: {message} не является валидным");
        }
    }
}
