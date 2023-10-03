using Module17.AccountTypes;

namespace Module17
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Account regularAccount = new RegularAccount
            {
                Type = "Обычный",
                Balance = 1000
            };

            //Расчет процентной ставки
            regularAccount.CalculateInterest();

            Console.WriteLine($"Тип учетной записи: {regularAccount.Type}");
            Console.WriteLine($"Баланс учетной записи: {regularAccount.Balance}");
            Console.WriteLine($"Процентная ставка: {regularAccount.Interest}");

            
            Account salaryAccount = new SalaryAccount
            {
                Type = "Зарплатный",
                Balance = 10000
            };

           
            salaryAccount.CalculateInterest();

            Console.WriteLine($"Тип учетной записи: {salaryAccount.Type}");
            Console.WriteLine($"Баланс учетной записи: {salaryAccount.Balance}");
            Console.WriteLine($"Процентная ставка: {salaryAccount.Interest}");

            Console.ReadLine();
        }
    }
}
