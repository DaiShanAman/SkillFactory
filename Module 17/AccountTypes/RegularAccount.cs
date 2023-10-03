namespace Module17.AccountTypes
{
    // Обычная учетка
    public class RegularAccount : Account
    {
        public override void CalculateInterest()
        {
            Interest = Balance * 0.4;

            if (Balance < 1000)
            {
                Interest -= Balance * 0.2;
                return;
            }
            // тут ифка не нужна, ибо если не ретюрнулось - то баланс >= 1000, хотя тут можно просто присвоить ноль...
            Interest -= Balance * 0.4;
        }
    }
}
