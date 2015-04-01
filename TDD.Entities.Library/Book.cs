using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Entities.Library
{
    public class Book : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual int? PublisherId { get; set; }

        public virtual List<Author> Authors { get; set; }

        public virtual decimal? Price { get; set; }

        public Book()
        {
            Authors = new List<Author>();
        }
    }
}
