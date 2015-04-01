using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Services.Library.TransportObjects;

namespace TDD.Windows
{
    public class BookViewModel
    {
        public BookTO TO { get; set; }

        public int BookId {
            get { return TO.Book.Id; }
        }

        public string Title
        {
            get { return TO.Book.Title; }
        }

        public decimal? VATPrice
        {
            get { return TO.VATPrice; }
        }

        public string Authors
        {
            get { return TO.AuthorsString; }
        }

    }
}
