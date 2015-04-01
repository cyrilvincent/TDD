using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TDD.Entities.Library;

namespace TDD.Repositories.Library.Stubs
{
    public class DbContextStub : DbContext, ITDDDbContext
    {
        public virtual IDbSet<Entities.Library.Author> Authors { get; set; }

        public virtual IDbSet<Entities.Library.Book> Books { get; set; }

        public virtual IDbSet<Entities.Library.Publisher> Publishers { get; set; }
    }
}
