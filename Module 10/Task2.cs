namespace Module_10_2
{
    internal class Program
    {
        static ILogger Logger { get; set; }
        public static void Main()
        {
            Logger = new Logger();
            Calculator calculator = new (Logger);

            calculator.CalcSum();
        }
    }

    public interface ICalcSum
    {
        void CalcSum();
    }

    public class Calculator : ICalcSum
    {
        ILogger Logger { get; }
        public Calculator(ILogger logger)
        {
            Logger = logger;
        }

        public void CalcSum()
        {
            try
            {
                Console.WriteLine("Введите первое слагаемое:");
                int x = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите второе слагаемое:");
                int y = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Результат сложения: {x + y}");
                Logger.Event("Задача выполнена");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }

        }
    }

    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine(message);
        }

        public void Event(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine(message);
        }
    }
}
