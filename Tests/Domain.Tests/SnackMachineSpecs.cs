using System;
using Domain.SnackMachine;
using FluentAssertions;
using Xunit;

namespace Tests.Domain.Tests
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void ReturnMoney_MoneyShouldReturnEmpty()
        {
            // Arrange
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Money.Dollar);
            // Act
            snackMachine.ReturnMoney();
            // Assert
            snackMachine.MoneyInTransaction?.Amount.Should().Be(0M);
        }

        [Fact]
        public void InsertedMoney_ShouldReturnMoneyInTransaction()
        {
            // Arrange
            var snackMachine = new SnackMachine();
            // Act
            snackMachine.InsertMoney(Money.Cent);
            snackMachine.InsertMoney(Money.Dollar);
            // Assert
            snackMachine.MoneyInTransaction?.Amount.Should().Be(1.01M);
        }

        [Fact]
        public void InsertMoreThanOneCoinAtTime_ShouldThrowAnException()
        {
            // Arrange
            var snackMachine = new SnackMachine();
            var twoCent = Money.Cent + Money.Cent;
            // Act
            Action action = () => snackMachine.InsertMoney(twoCent);
            // Assert
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void WhenBroughtSnack_ShouldMoneyInTransactionGoToMoneyInside()
        {
            // Arrange
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.InsertMoney(Money.Dollar);
            // Act
            snackMachine.BuySnack();
            // Assert
            snackMachine.MoneyInTransaction.Should().Be(Money.None);
            snackMachine.MoneyInside?.Amount.Should().Be(2M);
        }
    }
}