using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Entities.Library;
using TDD.Repositories.Library.Common;

namespace TDD.Repositories.Library
{
    public class BadBookRepository
    {
        private TDDDbContext context = new TDDDbContext();

        public Book GetById(int id)
        {
            var res = from b in context.Books
                      where b.Id == id
                      select b;
            return res.First();
        }

        public void Insert(int id, string title, decimal? price)
        {
            var book = (from b in context.Books
                     where b.Id == id
                     select b).FirstOrDefault();
            if (book != null)
            {
                context.Books.Add(new Book { Title = title, Price = price });
                context.SaveChanges();
            }
        }
    }
}
