using System;
using System.Text;

namespace EqualityOrderComparisonMoney
{
    public readonly struct Money : IEquatable<Money>, IComparable<Money>, IComparable
    {
        public Money(decimal moneyValue, CurrencyCode currency)
        {
            Check(moneyValue);
            MoneyValue = moneyValue;
            Currency = currency;
        }

        public decimal MoneyValue { get; init; }

        public CurrencyCode Currency { get; init; }

        private static void Check(decimal moneyValue)
        {
            Notification notification = Validate(moneyValue);
            
            if (notification.HasErrors)
            {
                throw new ArgumentException(notification.ErrorMessage);
            }
        }

        private static Notification Validate(decimal moneyValue)
        {
            var note = new Notification();
            ValidateMoneyValue(note, moneyValue);
            return note;
        }

        private static void ValidateMoneyValue(Notification note, decimal moneyValue)
        {
            if (moneyValue <= 0M)
            {
                note.AddError("MoneyValue should be greater than zero");
            }
        }

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
            return otherMoney.HasValue && Equals(otherMoney.Value);
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
                throw new InvalidOperationException("CompareTo() argument is not Money");
            }

            return CompareTo((Money) other);
        }

        public static bool operator ==(Money? m1, Money? m2)
            => m1.HasValue && m2.HasValue ? m1.Equals(m2) : !m1.HasValue && !m2.HasValue;

        public static bool operator !=(Money? m1, Money? m2)
            => m1.HasValue && m2.HasValue ? !m1.Equals(m2) : m1.HasValue ^ m2.HasValue;

        public static bool operator <(Money m1, Money m2)
            => m1.CompareTo(m2) < 0;

        public static bool operator >(Money m1, Money m2)
            => m1.CompareTo(m2) > 0;

        public static bool operator <=(Money m1, Money m2)
            => m1 == m2 || m1 < m2;

        public static bool operator >=(Money m1, Money m2)
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

        public static Money operator %(Money m, int divisor)
        {
            return new Money(m.MoneyValue % divisor, m.Currency);
        }

        public static Money operator ++(Money m)
        {
            return new Money(m.MoneyValue + 1M, m.Currency);
        }

        public static Money operator --(Money m)
        {
            return new Money(m.MoneyValue - 1M, m.Currency);
        }

        public static explicit operator decimal(Money m) => m.MoneyValue;
    }
}