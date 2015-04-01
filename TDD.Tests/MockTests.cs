using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Repositories.Library;
using System.Linq;
using TDD.Entities.Library;
using TDD.Repositories.Library.Stubs;
using System.Data.Entity;
using FakeDbSet;
using System.Collections.Generic;
using Moq;
using TDD.Repositories.Library.Common;

namespace TDD.Tests
{
    [TestClass]
    public class MockTests
    {
        // Nécessite Moq
        [TestMethod]
        public void T401MoqBookTest()
        {
            Mock<Book> mockWrapper = new Mock<Book>();
            Assert.AreEqual(0, mockWrapper.Object.Id);
        }

        [TestMethod]
        public void T402MoqEntityTest()
        {
            var mockWrapper = new Mock<IEntity>();
            IEntity entity = mockWrapper.Object;
            Assert.AreEqual(0, entity.Id);
        }

        //https://msdn.microsoft.com/en-us/library/gg696521(v=vs.113).aspx
        // Nécessite DbSet en virtual
        [TestMethod]
        public void T403DbSetTest()
        {
            IQueryable<Book> data = new List<Book> {
                new Book {Id = 1, Title="TDD"},
                new Book {Id = 2, Title="Moq"},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mock = new Mock<ITDDDbContext>();
            mock.Setup(c => c.Books).Returns(mockSet.Object);
            Assert.AreEqual(2, mock.Object.Books.Count());
        }

        private DbContext mockContext;
        private TDDDbContext mockTDDContext;

        [TestInitialize]
        public void Setup()
        {
            IQueryable<Book> data = new List<Book> {
                new Book {Id = 1, Title="TDD"},
                new Book {Id = 2, Title="Moq"},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockWrapperContext = new Mock<DbContext>();
            mockWrapperContext.Setup(c => c.Set<Book>()).Returns(mockSet.Object);
            mockContext = mockWrapperContext.Object;
            var mockWrapperTDDContext = new Mock<TDDDbContext>();
            mockWrapperTDDContext.Setup(c => c.Books).Returns(mockSet.Object);
            mockWrapperTDDContext.Setup(c => c.Set<Book>()).Returns(mockSet.Object);
            mockTDDContext = mockWrapperTDDContext.Object;
        }

        [TestMethod]
        public void T404MockContextTest()
        {
            Assert.AreEqual(2, mockContext.Set<Book>().Count());   
        }


        [TestMethod]
        public void T405MockTDDContextTest()
        {
            Assert.AreEqual(2, mockTDDContext.Books.Count());
            Assert.AreEqual(2, mockTDDContext.Set<Book>().Count());
        }

        [TestMethod]
        public void T407RepositoryMockContextTest()
        {
            BookRepository repo = new BookRepository();
            repo.DbContext = mockTDDContext;
            Assert.AreEqual(2, repo.Count());
        }
    }
}
