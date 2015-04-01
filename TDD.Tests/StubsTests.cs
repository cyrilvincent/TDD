using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Repositories.Library;
using System.Linq;
using TDD.Entities.Library;
using TDD.Repositories.Library.Stubs;
using System.Data.Entity;
using FakeDbSet;

namespace TDD.Tests
{
    [TestClass]
    public class StubsTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void T301DbContextStubNITest()
        {
            DbContextNIStub context = new DbContextNIStub();
            int c = context.Books.Count();
        }

        [TestMethod]
        public void T303DbContextStubTest()
        {
            DbContextStub context = new DbContextStub();
            context.Books = new InMemoryDbSet<Book>(true) {
                new Book {Id = 1, Title="TDD"}
            };
            int c = context.Books.Count();
            Assert.AreEqual(1, c);
        }

        [TestMethod]
        public void T304BookRepositoryStubTest()
        {
            DbContextStub context = new DbContextStub();
            context.Books = new InMemoryDbSet<Book>(true) {
                new Book {Id = 1, Title="TDD"}
            };
            BookRepositoryStub repo = new BookRepositoryStub();
            repo.DbContext = context;
            int c = repo.Count();
            Assert.AreEqual(1, c);
        }

        
    }
}
