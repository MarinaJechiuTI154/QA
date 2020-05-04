using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTest;

namespace TestTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Program.CreateMessage(),"string" );
        }
    }
}
