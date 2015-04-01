using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Entities.Library
{
    public class BadBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? PublisherId { get; set; }

        public List<Author> Authors { get; set; }

        public decimal? Price { get; set; }

        public BadBook(int id, string title, int publisherId, List<int> authorsId)
        {
            Authors = new List<Author>();
            Id = id;
            Title = title;
            PublisherId = publisherId;
        }

        public Book GetById(int id)
        {
            // ADO.NET ou EF
            return null;
        }
    }
}
