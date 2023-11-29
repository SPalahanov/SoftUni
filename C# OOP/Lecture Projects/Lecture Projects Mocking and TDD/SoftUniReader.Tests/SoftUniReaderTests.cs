using Moq;
using NuGet.Frameworks;
//using SoftUniReader.Tests.Fakes;

namespace SoftUniReader.Tests
{
    public class SoftUniReaderTests
    {
        [Test]
        public void SoftUniReaderReadsCorrectly()
        {
            Mock<IHTTPRequester> mock = new Mock<IHTTPRequester>();

            mock.Setup(h => h.GetData(It.IsAny<string>())).Returns("Hello");
            
            SoftUniReader reader = new SoftUniReader(mock.Object);

            string result = reader.ReadSoftUniData();

            Assert.AreEqual(27, result.Length);
        }
    }
}