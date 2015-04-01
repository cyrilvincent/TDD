using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Entities.Library;
using TDD.Repositories.Library.Common;

namespace TDD.Repositories.Library
{
    public class BookRepository : AbstractRepository<Book, TDDDbContext>
    {
        public IEnumerable<Book> GetByPublisherId(int id)
        {
            return Query(b => b.PublisherId == id);
        }

        public IEnumerable<Book> GetByWord(string word)
        {
            return Query(b => b.Title.ToUpper().Contains(word.ToUpper()));
        }

    }
}
