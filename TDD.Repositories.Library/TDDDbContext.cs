using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Entities.Library;
using TDD.Repositories.Library.Configurations;

namespace TDD.Repositories.Library
{
    public class TDDDbContext : DbContext, ITDDDbContext
    {
        public virtual IDbSet<Book> Books { get; set; }
        public virtual IDbSet<Author> Authors { get; set; }
        public virtual IDbSet<Publisher> Publishers { get; set; }

        static TDDDbContext()
        {
            //Database.SetInitializer<TDDDBContext>(null);
            Database.SetInitializer<TDDDbContext>(new DropCreateDatabaseIfModelChanges<TDDDbContext>());
            
        }

        public TDDDbContext()
            : base("Name=TDDDbContext")
        {
        }
        public TDDDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new PublisherConfiguration());
            modelBuilder.Configurations.Add(new AuthorConfiguration());
        }
    }
}
