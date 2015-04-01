using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Repositories.Library;
using System.Linq;
using TDD.Entities.Library;

namespace TDD.Tests
{
    [TestClass]
    public class EntitiesTests
    {
        [TestMethod]
        public void T001EntityTest()
        {
            Book b = new Book { Title = "TDD" };
            Assert.AreEqual("TDD", b.Title);
        }

        
    }
}
