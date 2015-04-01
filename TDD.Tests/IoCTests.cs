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
using TDD.Services.Library.IoC;
using Microsoft.Practices.Unity;
using TDD.Services.Library;

namespace TDD.Tests
{
    [TestClass]
    public class IoCTests
    {
        [TestMethod]
        public void T501IoCMockDbContextTest()
        {
            TDDDbContext context = UnityHelper.Resolve<TDDDbContext>();
            int c = context.Books.Count();
            Assert.AreEqual(2, c);
        }

        [TestMethod]
        public void T502IoCRepositoryMockTest()
        {
            BookRepository repo = UnityHelper.Resolve<BookRepository>();
            Assert.IsNotNull(repo.DbContext);
            int c = repo.Count();
            Assert.AreEqual(2, c);
            repo = UnityHelper.Resolve<BookRepository>();
            c = repo.Count();
            Assert.AreEqual(2, c);
        }

        [TestMethod]
        public void T503IoCServiceMockTest()
        {
            IUseCaseService service = UnityHelper.Resolve<IUseCaseService>();
            Assert.IsNotNull(service.BookRepository);
            Assert.IsNotNull(service.PublisherRepository);
            Assert.IsNotNull(service.AuthorRepository);
            Assert.IsNotNull(service.BookRepository.DbContext);
            int c = service.GetAllBooks().Count();
            Assert.AreEqual(2, c);
        }       
    }
}
