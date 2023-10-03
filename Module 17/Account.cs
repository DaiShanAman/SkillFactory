using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Базовый класс, содержащий тип учетной записи, баланс и процентную ставку
public abstract class Account
{
    public string Type { get; set; }
    public double Balance { get; set; }
    public double Interest { get; set; }

    // Метод, который должен быть реализован в производных классах
    public abstract void CalculateInterest();
}
