using System;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructor()
        {
            FootballTeam team = new FootballTeam("Levski", 15);

            string expectedName = "Levski";
            int expectedCapacity = 15;

            Assert.AreEqual(team.Name, expectedName);
            Assert.AreEqual(team.Capacity, expectedCapacity);
            Assert.AreEqual(team.Players.Count, 0);
        }

        [Test]
        public void TestNameThrowException()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam(null, 15));
            Assert.Throws<ArgumentException>(() => new FootballTeam("", 15));
            Assert.Throws<ArgumentException>(() => new FootballTeam(string.Empty, 15));
        }

        [Test]
        public void TestCapacityThrowException()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("Levski", 14));
            Assert.Throws<ArgumentException>(() => new FootballTeam("Levski", 0));
            Assert.Throws<ArgumentException>(() => new FootballTeam("Levski", -5));
        }

        [Test]
        public void TestAddNewPlayerCapacity()
        {
            FootballTeam team = new FootballTeam("Levski", 15);

            for (int i = 1; i <= 15; i++)
            {
                team.AddNewPlayer(new FootballPlayer($"Pesho{i}", i, "Goalkeeper"));
            }

            FootballPlayer player = new FootballPlayer("Pesho", 16, "Forward");

            var actualResult = team.AddNewPlayer(player);

            Assert.AreEqual(actualResult, "No more positions available!");
        }

        [Test]
        public void TestAddNewPlayerWorkCorrectly()
        {
            FootballTeam team = new FootballTeam("Levski", 15);

            FootballPlayer player = new FootballPlayer("Pesho", 18, "Forward");

            var actualResult = team.AddNewPlayer(player);


            Assert.AreEqual(actualResult, "Added player Pesho in position Forward with number 18");
        }

        [Test]
        public void TestPickPlayerPlayerWorkCorrectly()
        {
            FootballTeam team = new FootballTeam("Levski", 15);

            FootballPlayer player = new FootballPlayer("Pesho", 18, "Forward");

            team.AddNewPlayer(player);

            var actualResult = team.PickPlayer("Pesho");
            var actualResult2 = team.PickPlayer("Gosho");

            Assert.AreEqual(actualResult, player);
            Assert.AreEqual(actualResult2, null);
        }

        [Test]
        public void TestPlayerScoreWorkCorrectly()
        {
            FootballTeam team = new FootballTeam("Levski", 15);

            FootballPlayer player = new FootballPlayer("Pesho", 18, "Forward");

            team.AddNewPlayer(player);

            var actualResult = team.PlayerScore(18);

            Assert.AreEqual(actualResult, "Pesho scored and now has 1 for this season!");
            Assert.AreEqual(1, player.ScoredGoals);
        }
    }
}