using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD.Entities.Library
{
    public class Publisher : IEntity
    {
        public virtual int Id { get; set; }
        public virtual List<Book> Books { get; set; }
        public virtual string Name { get; set; }

        public Publisher()
        {
            Books = new List<Book>();
        }
    }
}
