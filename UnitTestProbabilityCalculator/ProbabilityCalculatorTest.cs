using NUnit.Framework;
using SeatAllocationProbabilityCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProbabilityCalculator
{
    [TestFixture]
    public class ProbabilityCalculatorTest
    {
        private ProbabilityCalculator _objectUnderTest;
        [Test]
        public void TestStateInitialisation()
        {
            // arrange
            _objectUnderTest = new ProbabilityCalculator(100, 50);

            //act
            var resultState  = _objectUnderTest.InitState(Enumerable.Range(1, 50));

            // assert
            Assert.AreEqual(resultState.Count, 50);
        }

        [Test]
        public void TestFindEmptySeat()
        {
            // arrange
            _objectUnderTest = new ProbabilityCalculator(100, 50);

            //act
            var resultState = _objectUnderTest.InitState(Enumerable.Range(1, 100));
            resultState[1].isEmpty = false;
            resultState[1].ticket = 1;
            var emptySeatInfo = _objectUnderTest.FindEmptySeat(resultState);

            // assert
            Assert.AreEqual(emptySeatInfo, 2);
        }
    }
}
