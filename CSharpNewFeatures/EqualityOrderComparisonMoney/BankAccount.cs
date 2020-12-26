namespace EqualityOrderComparisonMoney
{
    public class BankAccount
    {
        public AccountType AccountType { get; }
        public Money Balance { get; private set; }
        
        public CurrencyCode Currency { get; }
        
        public BankAccount(AccountType accountType, CurrencyCode currency)
        {
            this.AccountType = accountType;
            this.Currency = currency;
            this.Balance = new Money(0M, currency);
        }
        
        public BankAccount(AccountType accountType, Money balanceAmount)
        {
            this.AccountType = accountType;
            this.Currency = balanceAmount.Currency;
            this.Balance = balanceAmount;
        }

        public void Deposit(Money money)
        {
            this.Balance += money;
        }

        public Notification Withdraw(Money money)
        {
            Notification notification = ValidateWithdrawal(money);
    
            if (notification.HasErrors)
            {
                return notification;
            }
            
            this.Balance -= money;

            return notification;
        }

        private Notification ValidateWithdrawal(Money money)
        {
            var note = new Notification();
            ValidateMoneyAvailability(note, money);
            return note;
        }

        private void ValidateMoneyAvailability(Notification note, Money money)
        {
            if (AccountType != AccountType.CreditAccount && Balance < money)
            {
                note.AddError(
                    $"The Balance value: {Balance.MoneyValue} is less than withdrawal amount: {money.MoneyValue}");
            }
        }
    }
}