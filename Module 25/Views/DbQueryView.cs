namespace Module_25.Views
{
    public class DbQueryView
    {
        public void Show()
        {
            Console.WriteLine("1. Пользователи (нажмите 1)");
            Console.WriteLine("2. Книги (нажмите 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.dbQueryUsersView.Show();
                        break;
                    }
                case "2":
                    {
                        Program.dbQueryBooksView.Show();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такой команды не существует");
                        break;
                    }

            }
        }
    }
}
