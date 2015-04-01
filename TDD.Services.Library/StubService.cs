using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Services.Library
{
    public class StubService : IUseCaseService
    {
        public void AddAuthor(Entities.Library.Author a)
        {
            throw new NotImplementedException();
        }

        public void AddBook(Entities.Library.Book b)
        {
            throw new NotImplementedException();
        }

        public void AddPublisher(Entities.Library.Publisher p)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entities.Library.Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Library.Book> GetBooksByPublisherId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransportObjects.BookTO> SearchBooks(string words)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(int id)
        {
            throw new NotImplementedException();
        }

        public void RemovePublisher(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public Repositories.Library.BookRepository BookRepository
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Repositories.Library.AuthorRepository AuthorRepository
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Repositories.Library.PublisherRepository PublisherRepository
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public Entities.Library.Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
