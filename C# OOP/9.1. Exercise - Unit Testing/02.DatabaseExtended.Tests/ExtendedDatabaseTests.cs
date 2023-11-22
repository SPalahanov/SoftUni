using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            Person[] persons =
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Ivan_Ivan"),
                new Person(4, "Pesho_ivanov"),
                new Person(5, "Gosho_Naskov"),
                new Person(6, "Pesh-Peshov"),
                new Person(7, "Ivan_Kaloqnov"),
                new Person(8, "Ivan_Draganchov"),
                new Person(9, "Asen"),
                new Person(10, "Jivko"),
                new Person(11, "Toshko")
            };

            database = new Database(persons);
        }

        [Test]
        public void CreatingDataBaseCountShouldBeCorrect()
        {
            int expectedResult = 11;

            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CreatingDataBaseShouldThrowExceptionWhenCountIsMoreThan16()
        {
            Person[] persons =
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Ivan_Ivan"),
                new Person(4, "Pesho_ivanov"),
                new Person(5, "Gosho_Naskov"),
                new Person(6, "Pesh-Peshov"),
                new Person(7, "Ivan_Kaloqnov"),
                new Person(8, "Ivan_Draganchov"),
                new Person(9, "Asen"),
                new Person(10, "Jivko"),
                new Person(11, "Slavi"),
                new Person(12, "Mitko"),
                new Person(13, "Vasko"),
                new Person(14, "Varadin"),
                new Person(15, "Stamata"),
                new Person(16, "Toncho"),
                new Person(17, "Blago")
            };

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => database = new Database(persons));

            Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message);
        }

        [Test]
        public void DataBaseCounterShouldWorkCorrectly()
        {
            int expectedResult = 11;

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void DatabaseAddMethodShouldIncreaseCount()
        {
            Person person = new(12, "Slavi");

            database.Add(person);

            int expectedResult = 12;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExceptionIfCountIsMoreThan16()
        {
            Person person1 = new(12, "Slavi");
            Person person2 = new(13, "Qnko");
            Person person3 = new(14, "Varadin");
            Person person4 = new(15, "Rusi Rusev");
            Person person5 = new(16, "Dobri");

            database.Add(person1);
            database.Add(person2);
            database.Add(person3);
            database.Add(person4);
            database.Add(person5);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(17, "Rumen")));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExceptionIfThereIsAlreadyUserWithThisName()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(12, "Asen")));

            Assert.AreEqual("There is already user with this username!", exception.Message);
        }
        [Test]
        public void DatabaseAddMethodShouldThrowExceptionIfThereIsAlreadyUserWithThisId()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(3, "Slavi")));

            Assert.AreEqual("There is already user with this Id!", exception.Message);
        }

        [Test]
        public void DataBaseRemoveMethodShouldWorkCorrectly()
        {
            database.Remove();

            int expectedResult = 10;

            Assert.AreEqual(expectedResult, database.Count);
        }
        [Test]
        public void DataBaseRemoveMethodShouldThrowExceptionIffDatabaseIsEmpty()
        {
            database = new();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Remove());
            
        }

        [Test]
        public void DatabaseFindByUsernameMethodShouldWorkCorrectly()
        {
            string expectedResult = "Gosho";

            string actualResult = database.FindByUsername("Gosho").UserName;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseFindByUsernameMethodShouldBeCaseSensitive()
        {
            string expectedResult = "goSho";

            string actualResult = database.FindByUsername("Gosho").UserName;

            Assert.AreNotEqual(expectedResult, actualResult);
        }


        [TestCase(null)]
        [TestCase("")]
        public void DatabaseFindByUsernameMethodShouldThrowExceptionIfUserIsNullOrEmpty(string userName)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(()
                => database.FindByUsername(userName));

            Assert.AreEqual("Username parameter is null!", exception.ParamName);
        }

        [TestCase("Monika")]
        [TestCase("Mariq")]
        public void DatabaseFindByUsernameMethodShouldThrowExceptionIfUserNotExist(string userName)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.FindByUsername(userName));

            Assert.AreEqual("No user is present by this username!", exception.Message);
        }

        [Test]
        public void DatabaseFindByIdMethodShouldWorkCorrectly()
        {
            long expectedResult = 2;

            long actualResult = database.FindById(2).Id;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-15)]
        [TestCase(-1)]
        public void DatabaseFindByIdMethodShouldThrowExceptionIfIdIsNotPositive(long id)
        {
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(()
                => database.FindById(id));

            Assert.AreEqual("Id should be a positive number!", exception.ParamName);
        }

        [TestCase(12)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(35)]
        public void DatabaseFindByIdMethodShouldThrowExceptionIfIdIsNotFound(long id)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.FindById(id));

            Assert.AreEqual("No user is present by this ID!", exception.Message);
        }
    }
}