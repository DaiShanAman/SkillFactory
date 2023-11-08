using System;

namespace Module_19_Social_Network.BLL.Exceptions
{
    public class NullFieldException : Exception
    {
        public NullFieldException(string message) : base(message)
        {
            Console.WriteLine($"Ошибка: поле: {message} не должно быть пустым");
        }
    }
}
