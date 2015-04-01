using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Services.Library.TransportObjects;

namespace TDD.Web.Models
{
    public class BookViewModels
    {
        public List<BookViewModel> BookVMs { get; set; }
  
        public string SearchText { get; set; }

        public BookViewModels()
        {
            BookVMs = new List<BookViewModel>();
        }
    }
}
