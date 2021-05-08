using System;
using Domain.ValueObject;

namespace Domain.SnackMachine
{
    /// <summary>
    /// Value Object
    /// </summary>
    public class Money : ValueObject<Money>
    {
        public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);
        public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);
        public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
        public static readonly Money Quarter = new Money(0, 0, 1, 0, 0, 0);
        public static readonly Money Dollar = new Money(0, 0, 0, 1, 0, 0);
        public static readonly Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);
        public static readonly Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);

        public int OneCentCount { get; protected set; }
        public int TenCentCount { get; protected set; }
        public int QuarterCount { get; protected set; }
        public int OneDollarCount { get; protected set; }
        public int FiveDollarCount { get; protected set; }
        public int TwentyDollarCount { get; protected set; }

        public Money()
        {
        }

        public Money(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            if (oneCentCount < 0)
            {
                throw new InvalidOperationException();
            }

            if (tenCentCount < 0)
            {
                throw new InvalidOperationException();
            }

            if (quarterCount < 0)
            {
                throw new InvalidOperationException();
            }

            if (oneDollarCount < 0)
            {
                throw new InvalidOperationException();
            }

            if (fiveDollarCount < 0)
            {
                throw new InvalidOperationException();
            }

            if (twentyDollarCount < 0)
            {
                throw new InvalidOperationException();
            }

            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuarterCount = quarterCount;
            OneDollarCount = oneDollarCount;
            FiveDollarCount = fiveDollarCount;
            TwentyDollarCount = twentyDollarCount;
        }

        public decimal Amount =>
            OneCentCount * .01M +
            TenCentCount * .10M +
            QuarterCount * .25M +
            OneDollarCount +
            FiveDollarCount * 5 +
            TwentyDollarCount * 20;

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
                money1.OneCentCount - money2.OneCentCount,
                money1.TenCentCount - money2.TenCentCount,
                money1.QuarterCount - money2.QuarterCount,
                money1.OneDollarCount - money2.OneDollarCount,
                money1.FiveDollarCount - money2.FiveDollarCount,
                money1.TwentyDollarCount - money2.TwentyDollarCount
            );
        }

        public static Money operator +(Money money1, Money money2)
        {
            var sum = new Money(
                money1.OneCentCount + money2.OneCentCount,
                money1.TenCentCount + money2.TenCentCount,
                money1.QuarterCount + money2.QuarterCount,
                money1.OneDollarCount + money2.OneDollarCount,
                money1.FiveDollarCount + money2.FiveDollarCount,
                money1.TwentyDollarCount + money2.TwentyDollarCount
            );
            return sum;
        }

        protected override bool EqualsCore(Money? other)
        {
            if (other != null)
            {
                return OneCentCount == other.OneCentCount
                       && TenCentCount == other.TenCentCount
                       && QuarterCount == other.QuarterCount
                       && OneDollarCount == other.OneDollarCount
                       && FiveDollarCount == other.FiveDollarCount
                       && TwentyDollarCount == other.TwentyDollarCount;
            }

            return false;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hashCode = OneCentCount;
                hashCode = (hashCode * 397) ^ TenCentCount;
                hashCode = (hashCode * 397) ^ QuarterCount;
                hashCode = (hashCode * 397) ^ OneDollarCount;
                hashCode = (hashCode * 397) ^ FiveDollarCount;
                hashCode = (hashCode * 397) ^ TwentyDollarCount;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Amount < 1 ? $"¢{Amount * 100:0.00}" : $"${Amount}";
        }
    }
}