using Module_25.Repositories;
using Module_25.Views;

namespace Module_25
{
    class Program
    {
        static UserRepository userRepository;
        static BookRepository bookRepository;

        public static MainView mainView;
        public static EditDbView editDbView;
        public static EditDbUsersView editDbUsersView;
        public static EditDbBooksView editDbBooksView;
        public static DbQueryView dbQueryView;
        public static DbQueryUsersView dbQueryUsersView;
        public static DbQueryBooksView dbQueryBooksView;
        public static void Main(string[] args)
        {
            userRepository = new UserRepository();
            bookRepository = new BookRepository();

            mainView = new MainView();
            editDbView = new EditDbView();
            editDbUsersView = new EditDbUsersView(userRepository);
            editDbBooksView = new EditDbBooksView(bookRepository);
            dbQueryView = new DbQueryView();
            dbQueryUsersView = new DbQueryUsersView(userRepository);
            dbQueryBooksView = new DbQueryBooksView(bookRepository);


            while (true)
            {
                 mainView.Show();
            }

        }
    }
}