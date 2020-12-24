using System;

namespace EqualityOrderComparison
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var money = new Money()
            {
                MoneyValue = 120,
                Currency = CurrencyCode.Usd
            };

            Console.WriteLine($"money.ToString(): {money}");
            Console.WriteLine($"money.MoneyValue: {money.MoneyValue}");
            Console.WriteLine($"money.Currency: {money.Currency}");
        }
    }
    
    public struct Money
    {
        public Money(decimal moneyValue, CurrencyCode currency)
        {
            this.MoneyValue = moneyValue;
            this.Currency = currency;
        }
        
        public decimal MoneyValue { get; init; }
        
        public CurrencyCode Currency { get; init; } 
    }

    public enum CurrencyCode
    {
        Bgn,
        Usd,
        Eur
    }
}