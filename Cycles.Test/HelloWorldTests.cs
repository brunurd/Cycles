using System.Collections.Generic;
using Cycles.Test.Cycles;
using NUnit.Framework;

namespace Cycles.Test
{
    public class HelloWorldTests
    {
        [TearDown]
        public void TearDown()
        {
            Middlewares.RemoveAllListener();
        }
        
        [Test]
        public void IsActiveTest()
        {
            var helloWorldCycle = new HelloWorldCycle();
            Assert.True(helloWorldCycle.IsActive);
            
            helloWorldCycle.Start("Cycles");
            Assert.False(helloWorldCycle.IsActive);
            
            helloWorldCycle.Start("it's alive?");
            Assert.False(helloWorldCycle.IsActive);
        }

        [Test]
        public void MiddlewareTest()
        {
            List<string> states = new List<string> {"PreLoading", "Executing", "Ending"};

            Middlewares.AddListener(info =>
            {
                Assert.AreEqual("Cycles.Test.Cycles.HelloWorldCycle", info.cycleName);
                Assert.AreEqual("HelloWorldCycle", info.cycleShortName);
                Assert.True(states.Contains(info.state));
                
                var actual = (Data) info.data;
                Assert.AreEqual("Cycles", actual.name);
            });

            var helloWorldCycle = new HelloWorldCycle();
            helloWorldCycle.Start("Cycles");
        }
    }
}