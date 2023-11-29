using chainblock.Enumerations;
using chainblock.Exceptions;
using chainblock.Models;
using chainblock.Models.Interfaces;
using NUnit.Framework;
using System;

namespace chainblock.Test
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void ConstructorShouldInitializeTransactionProperly()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "GoShow", 1);

            //ClassicAssert.IsNotNull(transaction);
            Assert.That(transaction, Is.Not.Null);
        }
        
        [Test]
        public void ConstructorShouldInitializeIdProperly()
        {
            //Arrange
            int expectedId = 1;

            //Act
            ITransaction transaction = new Transaction(expectedId, TransactionStatus.Successfull, "Pesho", "GoShow", 1);

            //Assert

            //ClassicAssert.AreEqual(expectedId, transaction.Id);
            Assert.That(expectedId, Is.EqualTo(transaction.Id));
        }

        [Test]
        public void ConstructorShouldInitializeStatusProperly()
        {
            TransactionStatus expectedStatus = TransactionStatus.Successfull;

            ITransaction transaction = new Transaction(1, expectedStatus, "Pesho", "GoShow", 1);

            //ClassicAssert.AreEqual(expectedStatus, transaction.Status);
            Assert.That(expectedStatus, Is.EqualTo(transaction.Status));
        }

        [Test]
        public void ConstructorShouldInitializeFromProperly()
        {
            string expectedFrom = "GoShow";

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, expectedFrom, "GoShow", 1);

            //ClassicAssert.AreEqual(expectedFrom, transaction.From);
            Assert.That(expectedFrom, Is.EqualTo(transaction.From));
        }

        [Test]
        public void ConstructorShouldInitializeToProperly()
        {
            string expectedTo = "GoShow";

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", expectedTo, 1);

            //ClassicAssert.AreEqual(expectedTo, transaction.To);
            Assert.That(expectedTo, Is.EqualTo(transaction.To));
        }

        [Test]
        public void ConstructorShouldInitializeAmountProperly()
        {
            decimal expectedAmount = 123.23m;

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "GoShow", 123.23m);

            transaction.Amount = expectedAmount;

            //ClassicAssert.AreEqual(expectedAmount, transaction.Amount);
            Assert.That(expectedAmount, Is.EqualTo(transaction.Amount));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void IdSetterShouldThrowExceptionWithZeroOrNegativeId(int id)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => new Transaction(id, TransactionStatus.Failed, "Pesho", "GoShow", 123.4m));

            //ClassicAssert.AreEqual(TransactionExceptionMessage.IdNotPositiveNumber, exception.Message);
            Assert.That(TransactionExceptionMessage.IdNotPositiveNumber, Is.EqualTo(exception.Message));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void FromSetterShouldThrowExceptionWithNullOrWhiteSpace(string from)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => new Transaction(1, TransactionStatus.Failed, from, "Pesho", 123.4m));

            //ClassicAssert.AreEqual(TransactionExceptionMessage.FromNullOrWhiteSpace, exception.Message);
            Assert.That(TransactionExceptionMessage.FromNullOrWhiteSpace, Is.EqualTo(exception.Message));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void ToSetterShouldThrowExceptionWithNullOrWhiteSpace(string to)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => new Transaction(1, TransactionStatus.Failed, "Pesho", to, 123.4m));

            //ClassicAssert.AreEqual(TransactionExceptionMessage.ToNullOrWhiteSpace, exception.Message);
            Assert.That(TransactionExceptionMessage.ToNullOrWhiteSpace, Is.EqualTo(exception.Message));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void AmountSetterShouldThrowExceptionWithZeroOrNegativeAmount(decimal amount)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => new Transaction(1, TransactionStatus.Failed, "Pesho", "GoShow", amount));

            Assert.That(TransactionExceptionMessage.AmountNotPositiveNUmber, Is.EqualTo(exception.Message));
        }
    }
}