using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Entities.Library;

namespace TDD.Services.Library.TransportObjects
{
    public class BookTO
    {
        public Book Book { get; set; }
        public decimal? VATPrice {
            get
            {
                decimal? d = null;
                if (Book.Price != null)
                    d = ((decimal)Book.Price) * 1.05m;
                return d;
            }
        }

        public string AuthorsString
        {
            get
            {
                string s = String.Empty;
                foreach (Author a in Book.Authors)
                {
                    if (s != String.Empty)
                        s += ", ";
                    if (a.FirstName != null)
                        s += a.FirstName + " ";
                    s += a.LastName;
                }
                return s;   
            }

        }
    }
}
