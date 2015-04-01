using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Entities.Library;
using TDD.Repositories.Library;
using TDD.Services.Library.TransportObjects;

namespace TDD.Services.Library
{
    public class UseCaseService : IUseCaseService
    {
        public BookRepository BookRepository { get; set; }
        public AuthorRepository AuthorRepository { get; set; }
        public PublisherRepository PublisherRepository { get; set; }

        public void AddAuthor(Author a)
        {
            AuthorRepository.Insert(a);
            AuthorRepository.Save();
        }

        public void AddPublisher(Publisher p)
        {
            PublisherRepository.Insert(p);
            PublisherRepository.Save();
        }

        public void AddBook(Book b)
        {
            BookRepository.Insert(b);
            BookRepository.Save();
        }

        public IQueryable<Book> GetAllBooks()
        {
            return BookRepository.GetAll();
        }

        public IEnumerable<Book> GetBooksByPublisherId(int id)
        {
            return BookRepository.GetByPublisherId(id);
        }

        public IEnumerable<BookTO> SearchBooks(string words)
        {
            HashSet<Book> h = null;
            string[] tab = words.Split(' ');
            foreach (string s in tab)
            {
                IEnumerable<Book> ie = BookRepository.GetByWord(s);
                if (h == null)
                    h = new HashSet<Book>(ie);
                else
                    h.IntersectWith(ie);
            }
            return h.Select(b => new BookTO { Book = b });
        }

        public void RemoveBook(int id)
        {
            Book b = BookRepository.GetById(id);
            BookRepository.Remove(b);
            BookRepository.Save();
        }

        public void RemovePublisher(int id)
        {
            Publisher p = PublisherRepository.GetById(id);
            foreach (Book b in p.Books.ToList())
                BookRepository.Remove(b);
            PublisherRepository.Remove(p);
            PublisherRepository.Save();
        }

        public void RemoveAuthor(int id)
        {
            Author a = AuthorRepository.GetById(id);
            foreach (Book b in a.Books.ToList())
                BookRepository.Remove(b);
            AuthorRepository.Remove(a);
            AuthorRepository.Save();
        }

        public Book GetBookById(int id)
        {
            return BookRepository.GetById(id);
        }
    }
}
