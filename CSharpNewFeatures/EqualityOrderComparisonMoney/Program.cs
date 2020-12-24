using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityOrderComparisonMoney
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var m1 = new Money
            {
                MoneyValue = 120M,
                Currency = CurrencyCode.Usd
            };

            Console.WriteLine($"m1.ToString(): {m1}");
            Console.WriteLine($"m1.MoneyValue: {m1.MoneyValue}");
            Console.WriteLine($"m1.Currency: {m1.Currency}");

            var m2 = new Money(moneyValue: 120M, currency: CurrencyCode.Usd);

            Console.WriteLine($"Are m1 and m2 equal: {m1.Equals(m2)}");
            Console.WriteLine($"Is m1 equal to null: {m1.Equals(null)}");
            Console.WriteLine($"Is m2 equal to 'gosho': {m1.Equals("gosho")}");
            Console.WriteLine($"Is m2 equal to 5: {m1.Equals(5)}");

            Console.WriteLine($"m1 == m2: {m1 == m2}");
            Console.WriteLine($"m1 == m1: {m1 == m1}");

            Money? m3 = null;
            Money? m4 = null;

            Console.WriteLine($"m3.Equals(m4): {m3.Equals(m4)}");
            Console.WriteLine($"m3 == m4: {m3 == m4}");
            Console.WriteLine($"(object)null == (object)null: {(object) null == (object) null}");

            Money? m5 = null;
            Money? m6 = new Money(65M, CurrencyCode.Bgn);

            Console.WriteLine($"m5 == m6: {m5 == m6}");
            Console.WriteLine($"m5 != m6: {m5 != m6}");

            if (m5 is Money otherMoney1)
            {
                Console.WriteLine($"otherMoney: {otherMoney1}");
            }

            Console.WriteLine($"m5 is Money anotherMoney1: {m5 is Money anotherMoney1}");

            if (m6 is Money otherMoney2)
            {
                Console.WriteLine($"otherMoney2: {otherMoney2}");
            }

            Console.WriteLine($"m6 is Money anotherMoney2: {m6 is Money anotherMoney2}");

            var emptyList = new List<int>();
            Console.WriteLine($"Is m2 equal to emptyList: {m1.Equals(emptyList)}");

            List<int> nullList = null;
            Console.WriteLine($"Is m2 equal to nullList: {m1.Equals(nullList)}");

            Console.WriteLine($"m1.GetHashCode(): {m1.GetHashCode()}");
            Console.WriteLine($"m1.GetHashCode(): {m1.GetHashCode()}");

            Console.WriteLine($"m2.GetHashCode(): {m2.GetHashCode()}");
            Console.WriteLine($"m2.GetHashCode(): {m2.GetHashCode()}");

            Console.WriteLine($"Are m1 and m2 Hash Codes equal: {m1.GetHashCode() == m2.GetHashCode()}");
        }
    }

    public readonly struct Money : IEquatable<Money>
    {
        public Money(decimal moneyValue, CurrencyCode currency)
        {
            MoneyValue = moneyValue;
            Currency = currency;
        }

        public decimal MoneyValue { get; init; }

        public CurrencyCode Currency { get; init; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameof(Money));
            stringBuilder.Append(" { ");

            PrintMembers(stringBuilder);

            stringBuilder.Append(" }");
            return stringBuilder.ToString();
        }

        private void PrintMembers(StringBuilder builder)
        {
            builder.Append(nameof(MoneyValue));
            builder.Append(" = ");
            builder.Append(MoneyValue);

            builder.Append(", ");

            builder.Append(nameof(Currency));
            builder.Append(" = ");
            builder.Append(Currency.ToString());
        }

        public bool Equals(Money other)
            => Currency == other.Currency && MoneyValue == other.MoneyValue;

        public override bool Equals(object other)
            => other is Money otherMoney && Equals(otherMoney);

        public override int GetHashCode()
            => HashCode.Combine(MoneyValue, Currency);

        public static bool operator ==(Money m1, Money m2)
            => m1.Equals(m2);

        public static bool operator !=(Money m1, Money m2)
            => !(m1 == m2);
    }

    public enum CurrencyCode
    {
        Bgn,
        Usd,
        Eur
    }
}