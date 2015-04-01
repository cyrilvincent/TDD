using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Repositories.Library;
using System.Linq;
using TDD.Entities.Library;
using TDD.Repositories.Library.Stubs;
using System.Data.Entity;
using System.Collections.Generic;
using TDD.Repositories.Library.Common;
using TDD.Services.Library.IoC;
using Microsoft.Practices.Unity;
using TDD.Services.Library;

namespace TDD.IntegrationTests
{
    [TestClass]
    public class ServiceIntegrationTests
    {
        [TestMethod]
        public void T501IntegrationRemoveAllBooksTest()
        {
            IUseCaseService service = UnityHelper.Resolve<IUseCaseService>();
            foreach (Book b in service.GetAllBooks().ToList())
            {
                service.RemoveBook(b.Id);
            }
            Assert.AreEqual(0, service.GetAllBooks().Count());
        }

        [TestMethod]
        public void T502IntegrationAddBookTest()
        {
            IUseCaseService service = UnityHelper.Resolve<IUseCaseService>();
            int c = service.GetAllBooks().Count();
            Book b = new Book { Title = "TDD" };
            service.AddBook(b);
            Assert.AreEqual(c + 1, service.GetAllBooks().Count());
            b = service.GetBookById(b.Id);
            Assert.AreEqual("TDD", b.Title);
            b = new Book { Title = "TDD with Unity and Moq" };
            service.AddBook(b);
            Assert.AreEqual(c + 2, service.SearchBooks("tdd").Count());
            c = service.SearchBooks("tdd unity").Count();
            Assert.AreEqual(1, c);
        }

        [TestMethod]
        public void T503IntegrationAutonomousTest()
        {
            IUseCaseService service = UnityHelper.Resolve<IUseCaseService>();
            int c = service.GetAllBooks().Count();
            Book b = new Book { Title = "TDD" };
            service.AddBook(b);
            Assert.AreEqual(c + 1, service.GetAllBooks().Count());
            b = service.GetBookById(b.Id);
            Assert.AreEqual("TDD", b.Title);
            service.RemoveBook(b.Id);
            Assert.AreEqual(c, service.GetAllBooks().Count());

        }

        // Puis Enlever DropCreateDatabaseIfModelChanges dans le DbContext
       
        // Test First
        // Ne rien mettre dans la configuration
    }
}
