using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Repositories.Library;
using System.Linq;
using TDD.Entities.Library;

namespace TDD.Tests
{
    [TestClass]
    public class DbContextTests
    {
        [TestMethod]
        public void T101CreateTest()
        {
            TDDDbContext context = new TDDDbContext();
            int c = context.Books.Count();
            Assert.IsTrue(c >=  0);
        }

        [TestMethod]
        public void T102InsertTest()
        {
            TDDDbContext context = new TDDDbContext();
            int c = context.Books.Count();
            Book b = new Book { Title = "TDD" };
            context.Books.Add(b);
            context.SaveChanges();
            Assert.AreEqual(c + 1, context.Books.Count());
        }

        [TestMethod]
        public void T103RemoveTest()
        {
            TDDDbContext context = new TDDDbContext();
            int c = context.Books.Count();
            Book b = context.Books.First();
            context.Books.Remove(b);
            context.SaveChanges();
            Assert.AreEqual(c - 1, context.Books.Count());
        }
    }
}
