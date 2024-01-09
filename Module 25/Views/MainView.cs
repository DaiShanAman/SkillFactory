namespace Module_25.Views
{
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Редактировать данные (нажмите 1)");
            Console.WriteLine("Произвести запрос (нажмите 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.editDbView.Show();
                        break;
                    }
                case "2":
                    {
                        Program.dbQueryView.Show();
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
