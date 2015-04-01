using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Services.Library.TransportObjects;

namespace TDD.Web.Models
{
    public class BookAdapter
    {
        public static BookViewModel Adapt(BookTO to)
        {
            return new BookViewModel { TO = to };
        }

        public static List<BookViewModel> Adapt(IEnumerable<BookTO> tos)
        {
            return tos.Select(to => new BookViewModel { TO = to }).ToList();
        }
    }
}
