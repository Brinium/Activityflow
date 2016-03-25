using NUnit.Framework;
using System;

namespace StatefullWorkflow.Engine.Tests
{
    [TestFixture()]
    public class Test
    {
        [TearDown]
        public void TearDown()
        {
            //using console here just for sake of simplicity. 
            //Console.WriteLine(String.Format("{0}: {1}", TestContext.CurrentContext.Test.FullName, TestContext.CurrentContext.Result.Outcome));
        }

        [Test()]
        public void TestCase()
        {
        }
    }
}

