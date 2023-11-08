using Module_19_Social_Network.BLL.Exceptions;
using Module_19_Social_Network.BLL.Models;
using Module_19_Social_Network.BLL.Services;
using Module_19_Social_Network.PLL.Helpers;
using System;
namespace Module_19_Social_Network.PLL.Views
{
    public class AuthenticationView
    {
        UserService userService;
        public AuthenticationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.WriteLine("Введите почтовый адрес:");
            authenticationData.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            authenticationData.Password = Console.ReadLine();

            try
            {
                var user = this.userService.Authenticate(authenticationData);

                SuccessMessage.Show("Вы успешно вошли в социальную сеть!");
                SuccessMessage.Show("Добро пожаловать " + user.FirstName);

                Program.userMenuView.Show(user);
            }

            catch (WrongPasswordException)
            {
                AlertMessage.Show("Пароль не корректный!");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            /// остальные исключения сделал в другой манере, ибо так их лично мне удобнее контроллировать,
            /// в случае командной разработки это будет, очевидно, уже не мое, а командное решение
            /// но тут я думаю что могу себе позволить сделать как удобно мне)))
        }
    } 
}
