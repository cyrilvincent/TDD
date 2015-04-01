using System;
using System.Collections.Generic;
using System.Data.Entity;
using TDD.Entities.Library;
namespace TDD.Repositories.Library
{
    public interface ITDDDbContext
    {
        IDbSet<Author> Authors { get; set; }
        IDbSet<Book> Books { get; set; }
        IDbSet<Publisher> Publishers { get; set; }
    }
}
