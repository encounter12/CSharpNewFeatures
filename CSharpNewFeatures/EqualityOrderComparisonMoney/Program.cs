using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine($"m14 > m13: {m14 > m13}");
            Console.WriteLine($"m13 > m13: {m13 > m13}");
            Console.WriteLine($"m13 == m13: {m13 == m13}");

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

            var m31 = new Money();
            Console.WriteLine($"m31.ToString(): {m31.ToString()}");

            var m32 = new Money(5.5M, CurrencyCode.Bgn);
            var m33 = m32 % 2;
            Console.WriteLine($"m33 = m32 % 3: {m33}");
            Console.WriteLine($"5.5M % 2: {5.5M % 2}");

            m33++;
            Console.WriteLine($"m33++: {m33}");
            Console.WriteLine($"m33++: {m33++}");
            Console.WriteLine($"++m33: {++m33}");

            var emptyList = new List<int>();
            Console.WriteLine($"Is m2 equal to emptyList: {m1.Equals(emptyList)}");

            List<int> nullList = null;
            Console.WriteLine($"Is m2 equal to nullList: {m1.Equals(nullList)}");

            Console.WriteLine($"m1.GetHashCode(): {m1.GetHashCode()}");
            Console.WriteLine($"m1.GetHashCode(): {m1.GetHashCode()}");

            Console.WriteLine($"m2.GetHashCode(): {m2.GetHashCode()}");
            Console.WriteLine($"m2.GetHashCode(): {m2.GetHashCode()}");

            Console.WriteLine($"Are m1 and m2 Hash Codes equal: {m1.GetHashCode() == m2.GetHashCode()}");

            var searchedMoney = new Money(10M, CurrencyCode.Bgn);

            var moneyList = new List<Money>()
            {
                new Money(10M, CurrencyCode.Bgn),
                new Money(15.5M, CurrencyCode.Bgn),
                new Money(120.50M, CurrencyCode.Bgn),
                new Money(10M, CurrencyCode.Bgn)
            };

            var moneyExists = moneyList.Contains(searchedMoney);

            Console.WriteLine($"moneyList.Contains(searchedMoney): {moneyExists}");

            var indexOfSearchedMoney = moneyList.IndexOf(searchedMoney);
            Console.WriteLine($"moneyList.IndexOf(searchedMoney): {indexOfSearchedMoney}");

            var lastIndexOfSearchedMoney = moneyList.LastIndexOf(searchedMoney);
            Console.WriteLine($"moneyList.IndexOf(searchedMoney): {lastIndexOfSearchedMoney}");

            var m34 = new Money(10M, CurrencyCode.Bgn);

            // var dict4 = new Dictionary<Money, string>()
            // {
            //     { m34, "John"},
            //     { m34, "John"}
            // };

            //dict.Add(new Money(10M, CurrencyCode.Bgn), "Gosho");

            var dict = new Dictionary<Money, string>()
            {
                [m34] = "John",
                [m34] = "John"
            };

            var containsMoneyKey = dict.ContainsKey(m34);

            Console.WriteLine($"dict.ContainsKey(new Money(10, CurrencyCode.Bgn)):{containsMoneyKey}");
            Console.WriteLine($"dict.Count:{dict.Count}");

            var dict2 = new Dictionary<Money, string>()
            {
                {new Money(10M, CurrencyCode.Bgn), "Mike"},
                {new Money(15M, CurrencyCode.Bgn), "John"},
                {new Money(25.5M, CurrencyCode.Bgn), "Lisa"}
            };

            var containsMoneyKey2 = dict2.ContainsKey(new Money(15M, CurrencyCode.Bgn));
            Console.WriteLine($"dict2.ContainsKey(new Money(15M, CurrencyCode.Bgn)):{containsMoneyKey2}");

            var containsMoneyKey3 = dict2.ContainsKey(new Money(41.5M, CurrencyCode.Bgn));
            Console.WriteLine($"dict2.ContainsKey(new Money(41.5M, CurrencyCode.Bgn)):{containsMoneyKey3}");

            var containsMoneyKey4 = dict2.ContainsKey(new Money(10M, CurrencyCode.Usd));
            Console.WriteLine($"dict2.ContainsKey(new Money(10M, CurrencyCode.Usd)):{containsMoneyKey4}");

            //var m35 = new Money(-4.5M, CurrencyCode.Bgn);
        }
    }
}