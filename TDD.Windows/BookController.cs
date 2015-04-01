using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Services.Library;
using TDD.Services.Library.IoC;

namespace TDD.Windows
{
    public class BookController
    {
        public List<BookViewModel> Search(string words)
        {
            IUseCaseService service = UnityHelper.Resolve<IUseCaseService>();
            return BookAdapter.Adapt(service.SearchBooks(words));
        }
    }
}
