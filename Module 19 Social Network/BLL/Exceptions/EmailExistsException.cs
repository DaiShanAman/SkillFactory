using System;

namespace Module_19_Social_Network.BLL.Exceptions
{
    public class EmailExistsException : Exception
    {
        public EmailExistsException (string message) : base(message)
        {
            Console.WriteLine($"Ошибка: адрес: {message} занят другим пользователем");
        }
    }
}
