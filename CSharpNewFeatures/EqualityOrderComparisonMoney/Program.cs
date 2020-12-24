using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityOrderComparisonMoney
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var m1 = new Money()
            {
                MoneyValue = 120,
                Currency = CurrencyCode.Usd
            };

            Console.WriteLine($"m1.ToString(): {m1}");
            Console.WriteLine($"m1.MoneyValue: {m1.MoneyValue}");
            Console.WriteLine($"m1.Currency: {m1.Currency}");

            var m2 = new Money(moneyValue: 120, currency: CurrencyCode.Usd);
            
            Console.WriteLine($"Are m1 and m2 equal: {m1.Equals(m2)}");
        }
    }
    
    public readonly struct Money : IEquatable<Money>
    {
        public Money(decimal moneyValue, CurrencyCode currency)
        {
            this.MoneyValue = moneyValue;
            this.Currency = currency;
        }
        
        public decimal MoneyValue { get; init; }
        
        public CurrencyCode Currency { get; init; }
        
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameof(Money));
            stringBuilder.Append(" { ");
            
            this.PrintMembers(stringBuilder);
            
            stringBuilder.Append(" }");
            return stringBuilder.ToString();
        }
        
        private void PrintMembers(StringBuilder builder)
        {
            builder.Append(nameof(MoneyValue));
            builder.Append(" = ");
            builder.Append(this.MoneyValue);
        
            builder.Append(", ");
        
            builder.Append(nameof(Currency));
            builder.Append(" = ");
            builder.Append(this.Currency.ToString());
        }

        public bool Equals(Money other)
            => this.Currency == other.Currency && this.MoneyValue == other.MoneyValue;
        
        public override bool Equals(object other)
            => other is Money otherMoney && this.Equals(otherMoney);
        
        public override int GetHashCode()
            => HashCode.Combine(
                EqualityComparer<decimal>.Default.GetHashCode(this.MoneyValue),
                EqualityComparer<CurrencyCode>.Default.GetHashCode(this.Currency));
        
    }

    public enum CurrencyCode
    {
        Bgn,
        Usd,
        Eur
    }
}