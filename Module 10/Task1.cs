namespace Module_10_1
{
    internal class Program
    {

        public static void Main()
        {
            try
            {
                Console.WriteLine("Введите первое слагаемое:");
                int x = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите второе слагаемое:");
                int y = Convert.ToInt32(Console.ReadLine());

                ICalcSum calcSum = new Calculator();
                int result = calcSum.CalcSum(x, y);

                Console.WriteLine($"Сумма равна: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }

    interface ICalcSum
    {
        int CalcSum(int a, int b);
    }

    class Calculator : ICalcSum
    {
        int ICalcSum.CalcSum(int a, int b)
        {
            return a + b;
        }
    }
}