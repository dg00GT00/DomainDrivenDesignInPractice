using System;
using System.Linq;

namespace Domain.SnackMachine
{
    /// <summary>
    /// Entity
    /// </summary>
    public sealed class SnackMachine : Entity.Entity
    {
        public Money? MoneyInside { get; private set; } = Money.None;
        public Money? MoneyInTransaction { get; private set; } = Money.None;

        public void InsertMoney(Money money)
        {
            var coinsAndNotes = new[]
                {Money.Cent, Money.TenCent, Money.Quarter, Money.Dollar, Money.FiveDollar, Money.TwentyDollar};
            if (!coinsAndNotes.Contains(money))
            {
                throw new InvalidOperationException(
                    "The snack machine accepts only one money instance at insertion time");
            }

            if (MoneyInTransaction != null) MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = Money.None;
        }

        public void BuySnack()
        {
            if (MoneyInside == null || MoneyInTransaction == null) return;
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = Money.None;
        }
    }
}