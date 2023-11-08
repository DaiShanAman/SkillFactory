using Module_19_Social_Network.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module_19_Social_Network.PLL.Views
{
    public class UserFriendView
    {
        public void Show(IEnumerable<User> friends)
        {
            Console.WriteLine("Список друзей");

            if (friends.Count() == 0)
            {
                Console.WriteLine("Друзей нет");
                return;
            }

            friends.ToList().ForEach(friend =>
            {
                Console.WriteLine("Почта друга: {0}. Имя: {1}. Фамилия: {2}", friend.Email, friend.FirstName, friend.LastName);
            });
        }

    }
}

