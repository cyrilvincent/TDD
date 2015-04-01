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
    public class BadService
    {
        private BookRepository bookRepository = new BookRepository();
        private AuthorRepository authorRepository = new AuthorRepository();
        private PublisherRepository publisherRepository = new PublisherRepository();

        public BadService(string hugeConfiguration)
        {
            bookRepository.DbContext = new TDDDbContext(); // or Coded Singleton
            authorRepository.DbContext = new TDDDbContext(); // or Coded Singleton
            publisherRepository.DbContext = new TDDDbContext(); // or Coded Singleton
        }
        
        // Méthods with huge parameters
    }
}
