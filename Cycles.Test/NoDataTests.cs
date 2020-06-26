using Cycles.Test.Cycles;
using NUnit.Framework;

namespace Cycles.Test
{
    public class NoDataTests
    {
        [Test]
        public void PureStatesTests()
        {
            var noDataCycle = new NoDataCycle();
            Assert.AreEqual(NoDataState.One, noDataCycle.State);
            
            noDataCycle.State = NoDataState.Two;
            Assert.AreEqual(NoDataState.Two, noDataCycle.State);

            noDataCycle.State = NoDataState.Three;
            Assert.AreEqual(NoDataState.Three, noDataCycle.State);
        }
    }
}