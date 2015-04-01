using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Repositories.Library;
using System.Linq;
using TDD.Entities.Library;
using System.Collections.Generic;

namespace TDD.Tests
{
    [TestClass]
    public class RepositoriesTests
    {
        [TestMethod]
        public void T201RepositoryTest()
        {
            TDDDbContext context = new TDDDbContext();
            BookRepository r = new BookRepository { DbContext = context };
            Book b = new Book { Title = "EF" };
            Publisher p = new Publisher { Name = "My publisher" };
            Author a = new Author { LastName = "Vincent" };
            b.Authors.Add(a);
            b.Publisher = p;
            r.Insert(b);
            r.Save();
            IEnumerable<Book> l = r.GetByWord("EF");
            b = l.FirstOrDefault();
            Assert.IsNotNull(b.Publisher);
            Assert.AreEqual(1, b.Authors.Count());

        }
    }
}
