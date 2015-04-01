using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Entities.Library;
using TDD.Repositories.Library.Common;

namespace TDD.Repositories.Library.Stubs
{
    public class BookRepositoryStub : AbstractRepository<Book, DbContextStub>
    {
        public override int Count()
        {
            return DbContext.Books.Count();
        }
    }
}
