using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Repositories.Library.Stubs
{
    public class DbContextNIStub : DbContext, ITDDDbContext
    {
        public System.Data.Entity.IDbSet<Entities.Library.Author> Authors
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Data.Entity.IDbSet<Entities.Library.Book> Books
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Data.Entity.IDbSet<Entities.Library.Publisher> Publishers
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
