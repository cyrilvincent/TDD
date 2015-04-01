using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD.Entities.Library
{
    public class Author : IEntity
    {
        public virtual int Id { get; set; }
        public virtual List<Book> Books { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }
    }
}
