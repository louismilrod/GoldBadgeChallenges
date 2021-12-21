using _02_Komodo_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_KomodoClaims_Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Claims_Repository _repo = new Claims_Repository();

        [TestMethod]
        public void TestMethod1()
        {
            _repo.GetAllClaims();
        }
    }
}
