namespace Module17.AccountTypes
{
      // Зарплатная учетка
    public class SalaryAccount : Account
    {
        public override void CalculateInterest()
        {
            Interest = Balance * 0.5;
        }
    }
}
