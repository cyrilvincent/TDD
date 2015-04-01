using System;
using System.Collections.Generic;
using System.Linq;
using TDD.Entities.Library;
using TDD.Repositories.Library;
using TDD.Services.Library.TransportObjects;
namespace TDD.Services.Library
{
    public interface IUseCaseService : IService
    {
        BookRepository BookRepository { get; set; }
        AuthorRepository AuthorRepository { get; set; }
        PublisherRepository PublisherRepository { get; set; }
        void AddAuthor(Author a);
        void AddBook(Book b);
        void AddPublisher(Publisher p);
        IQueryable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByPublisherId(int id);
        IEnumerable<BookTO> SearchBooks(string words);
        Book GetBookById(int id);
        void RemoveBook(int id);
        void RemovePublisher(int id);
        void RemoveAuthor(int id);
    }
}
