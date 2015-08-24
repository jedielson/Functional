using System;
using Functional.Data.Nhibernate.SqlServer.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Functional.Tests.Autorun
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (UnidadeDeTrabalhoNh udt = new UnidadeDeTrabalhoNh())
            {
                bool teste = true;
                Assert.AreEqual(true, teste);
            }
        }
    }
}
