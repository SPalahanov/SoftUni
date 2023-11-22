using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathHelper.Tests
{
    public class MathOperationHelperTests
    {
        [Test]
        public void Sum_Should_Sum_Correctly()
        {
            MathOperationHelper helper = new MathOperationHelper();

            Assert.AreEqual(10, helper.Sum(5, 5), "ne mojesh da suberesh dve chisla");
        }

        [Test]
        public void Sum_Should_Work_Correctly_With_Negative_Numbers()
        {
            MathOperationHelper helper = new MathOperationHelper();

            Assert.AreEqual(-11, helper.Sum(-5, -6), "ne mojesh da suberesh dve chisla");
        }
    }
}
