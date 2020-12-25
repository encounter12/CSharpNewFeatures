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

            int? nullableVar = 14;
            Console.WriteLine($"Is m2 equal to nullableVar: {m1.Equals(nullableVar)}");

            Console.WriteLine($"m1 == m2: {m1 == m2}");
            Console.WriteLine($"m1 == m1: {m1 == m1}");
            Console.WriteLine($"m1 != m2: {m1 != m2}");

            Money? m3 = null;
            Money? m4 = null;

            Console.WriteLine($"m3.Equals(m4): {m3.Equals(m4)}");
            Console.WriteLine($"m3 == m4: {m3 == m4}");
            Console.WriteLine($"(object)null == (object)null: {(object) null == (object) null}");

            Money? m5 = null;
            Money? m6 = new Money(65M, CurrencyCode.Bgn);

            Console.WriteLine($"m5.Equals(m5): {m5.Equals(m5)}");

            Console.WriteLine($"m6 == m5: {m6 == m5}");
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

            var m7 = new Money(42, CurrencyCode.Eur);
            Money? m8 = new Money(42, CurrencyCode.Eur);
            Console.WriteLine($"m7.Equals(m8): {m7.Equals(m8)}");

            Money? m9 = null;
            Money? m10 = new Money(143, CurrencyCode.Eur);
            Console.WriteLine($"m9.Equals(m10): {m9.Equals(m10)}");
            
            var m11 = new Money(470, CurrencyCode.Eur);
            var m12 = new Money(140, CurrencyCode.Eur);
            Console.WriteLine($"m11 > m12: {m11 > m12}");
            Console.WriteLine($"m11 >= m12: {m11 >= m12}");
            Console.WriteLine($"m11 < m12: {m11 < m12}");
            Console.WriteLine($"m11 <= m12: {m11 <= m12}");
            
            Money? m13 = null;
            var m14 = new Money(140, CurrencyCode.Eur);
            Console.WriteLine($"m13 > m14: {m13 > m14}");

            var m15 = new Money(30, CurrencyCode.Eur);
            Money? m16 = new Money(70, CurrencyCode.Eur);
            Console.WriteLine($"m15 > m16: {m15 > m16}");
            Console.WriteLine($"m15 < m16: {m15 < m16}");
            
            var m17 = new Money(30.5M, CurrencyCode.Eur);
            var m18 = new Money(70, CurrencyCode.Eur);
            var m19 = m17 + m18;
            Console.WriteLine($"m19 = m17 + m18: {m19}");

            m19 += 10;
            Console.WriteLine($"m19 += 10: {m19}");

            var m20 = m19 + 10;
            Console.WriteLine($"m20 = m19 + 10: {m20}");

            var m21 = new Money(20.5M, CurrencyCode.Bgn);
            var m22 = new Money(3M, CurrencyCode.Bgn);
            var m23 = m21 * m22;
            Console.WriteLine($"m23 = m21 * m22: {m23}");
            
            var m24 = new Money(48.9M, CurrencyCode.Bgn);
            var m25 = new Money(3M, CurrencyCode.Bgn);
            var m26 = m24 / m25;
            Console.WriteLine($"m26 = m24 / m25: {m26}");
            
            var m27 = m24 / 3;
            Console.WriteLine($"m27 = m24 / 3: {m27}");
            
            var m28 = 90 / m25;
            Console.WriteLine($"m28 = 90 / m25: {m28}");
            
            var m29 = new Money(3M, CurrencyCode.Bgn);
            var m30 = 100 / m29;
            Console.WriteLine($"m30 = 100 / m29: {m30}");

            var m30MoneyValue = (decimal) m30;
            Console.WriteLine($"m30MoneyValue = (decimal) m30: {m30MoneyValue}");
            
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

    public readonly struct Money : IEquatable<Money>, IComparable<Money>, IComparable
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
        {
            var otherMoney = other as Money?;
            return otherMoney.HasValue && Equals (otherMoney.Value);
        }

        public override int GetHashCode()
            => HashCode.Combine(MoneyValue, Currency);
        
        public int CompareTo(Money other)
        {
            if (Currency != other.Currency)
            {
                throw new InvalidOperationException("Cannot compare money of different currencies");
            }
            
            return Equals(other) ? 0 : MoneyValue.CompareTo(other.MoneyValue);
        }
        
        public int CompareTo(object other)
        {
            if (!(other is Money))
            {
                throw new InvalidOperationException ("CompareTo() argument is not Money");
            }
            
            return CompareTo ((Money) other);
        }

        public static bool operator ==(Money? m1, Money? m2)
            =>  m1.HasValue && m2.HasValue ? m1.Equals(m2) : !m1.HasValue && !m2.HasValue;
        
        public static bool operator !=(Money? m1, Money? m2)
            => m1.HasValue && m2.HasValue ? !m1.Equals(m2) : m1.HasValue ^ m2.HasValue;
        
        public static bool operator < (Money m1, Money m2)
            => m1.CompareTo (m2) < 0;

        public static bool operator > (Money m1, Money m2)
            => m1.CompareTo (m2) > 0;
        
        public static bool operator <= (Money m1, Money m2)
            => m1 == m2 || m1 < m2;
        
        public static bool operator >= (Money m1, Money m2)
            => m1 == m2 || m1 > m2;

        public static Money operator +(Money m1, Money m2)
        {
            if (m1.Currency != m2.Currency)
            {
                throw new InvalidOperationException("Cannot add money having different currencies");
            }

            return new Money(m1.MoneyValue + m2.MoneyValue, m1.Currency);
        }
        
        public static Money operator +(Money m1, decimal m2Value)
        {
            return new Money(m1.MoneyValue + m2Value, m1.Currency);
        }
        
        public static Money operator +(decimal m1Value, Money m2)
        {
            return new Money(m1Value + m2.MoneyValue, m2.Currency);
        }
        
        public static Money operator -(Money m1, Money m2)
        {
            if (m1.Currency != m2.Currency)
            {
                throw new InvalidOperationException("Cannot subtract money having different currencies");
            }
            
            return new Money(m1.MoneyValue - m2.MoneyValue, m1.Currency);
        }
        
        public static Money operator -(Money m1, decimal m2Value)
        {
            return new Money(m1.MoneyValue - m2Value, m1.Currency);
        }
        
        public static Money operator -(decimal m1Value, Money m2)
        {
            return new Money(m1Value - m2.MoneyValue, m2.Currency);
        }
        
        public static Money operator *(Money m1, Money m2)
        {
            if (m1.Currency != m2.Currency)
            {
                throw new InvalidOperationException("Cannot multiply money having different currencies");
            }
            
            return new Money(m1.MoneyValue * m2.MoneyValue, m1.Currency);
        }
        
        public static Money operator *(Money m1, decimal m2Value)
        {
            return new Money(m1.MoneyValue * m2Value, m1.Currency);
        }
        
        public static Money operator *(decimal m1Value, Money m2)
        {
            return new Money(m1Value * m2.MoneyValue, m2.Currency);
        }
        
        public static Money operator /(Money m1, Money m2)
        {
            if (m1.Currency != m2.Currency)
            {
                throw new InvalidOperationException("Cannot divide money having different currencies");
            }
            
            return new Money(m1.MoneyValue / m2.MoneyValue, m1.Currency);
        }
        
        public static Money operator /(Money m1, decimal m2Value)
        {
            return new Money(m1.MoneyValue / m2Value, m1.Currency);
        }
        
        public static Money operator /(decimal m1Value, Money m2)
        {
            return new Money(m1Value / m2.MoneyValue, m2.Currency);
        }
        
        public static explicit operator decimal(Money m) => m.MoneyValue;
    }

    public enum CurrencyCode
    {
        Bgn,
        Usd,
        Eur
    }
}