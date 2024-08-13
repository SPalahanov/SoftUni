namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructor()
        {
            RailwayStation station = new RailwayStation("Station");

            Assert.AreEqual("Station", station.Name);
            Assert.IsEmpty(station.ArrivalTrains);
            Assert.IsEmpty(station.DepartureTrains);
        }

        [Test]
        public void StationNameThrowException()
        {
            Assert.Throws<ArgumentException>(() => new RailwayStation(null));
            Assert.Throws<ArgumentException>(() => new RailwayStation(string.Empty));
            Assert.Throws<ArgumentException>(() => new RailwayStation(""));
        }

        [Test]
        public void TestNewArrivalOnBoard()
        {
            RailwayStation station = new RailwayStation("Station");

            station.NewArrivalOnBoard("TrainInfo");

            Assert.IsNotEmpty(station.ArrivalTrains);
        }

        [Test]
        public void TestTrainHasArrivedThrowExceptionOtherTrain()
        {
            RailwayStation station = new RailwayStation("Station");

            station.NewArrivalOnBoard("TrainInfo");
            station.NewArrivalOnBoard("TrainInfo2");

            station.TrainHasArrived("TrainInfo1");

            Assert.AreEqual("There are other trains to arrive before TrainInfo2.", station.TrainHasArrived("TrainInfo2"));
        }

        [Test]
        public void TestTrainHasArrivedWorkCorrectly()
        {
            RailwayStation station = new RailwayStation("Station");

            station.NewArrivalOnBoard("TrainInfo");
            station.NewArrivalOnBoard("TrainInfo2");

            Assert.AreEqual("TrainInfo is on the platform and will leave in 5 minutes.", station.TrainHasArrived("TrainInfo"));
            Assert.AreEqual(1, station.ArrivalTrains.Count);
            Assert.AreEqual(1, station.DepartureTrains.Count);
        }

        [Test]
        public void TrainHasLeftReturnTrue()
        {
            RailwayStation station = new RailwayStation("Station");

            station.NewArrivalOnBoard("TrainInfo");
            station.NewArrivalOnBoard("TrainInfo2");

            station.TrainHasArrived("TrainInfo");
            
            Assert.AreEqual(true, station.TrainHasLeft("TrainInfo"));
            Assert.AreEqual(0, station.DepartureTrains.Count);
            
        }

        [Test]
        public void TrainHasLeftReturnfalse()
        {
            RailwayStation station = new RailwayStation("Station");

            station.NewArrivalOnBoard("TrainInfo");
            station.NewArrivalOnBoard("TrainInfo2");

            station.TrainHasArrived("TrainInfo");

            Assert.AreEqual(false, station.TrainHasLeft("TrainInfo2"));
            Assert.AreEqual(1, station.DepartureTrains.Count);

        }
    }
}