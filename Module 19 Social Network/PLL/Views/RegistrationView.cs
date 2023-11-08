using Module_19_Social_Network.BLL.Models;
using Module_19_Social_Network.BLL.Services;
using Module_19_Social_Network.PLL.Helpers;
using System;

namespace Module_19_Social_Network.PLL.Views
{
    public class RegistrationView
    {
        UserService userService;
        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.Write("Для создания нового профиля введите ваше имя:\n");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Ваша фамилия:\n");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Пароль:\n");
            userRegistrationData.Password = Console.ReadLine();

            Console.Write("Почтовый адрес:\n");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                this.userService.Register(userRegistrationData);

                SuccessMessage.Show("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
            }

            catch (ArgumentNullException ex)
            {
                AlertMessage.Show("Поле не может быть пустым.");
                Console.Write(ex);
            }

            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка при регистрации.");
                Console.Write(ex);
            }
        }
    }
}
