using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Entities.Library;

namespace TDD.Repositories.Library.Configurations
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration(string schema = "dbo.")
        {
            ToTable(schema + "Book");
            HasKey(x => x.Id);

            Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).IsRequired().HasMaxLength(200);
            Property(x => x.Price).IsOptional();

            HasOptional(x => x.Publisher).WithMany(y => y.Books).HasForeignKey(x => x.PublisherId);
            HasMany(x => x.Authors).WithMany(y => y.Books).Map(z => 
                   { 
                       z.ToTable("BookAuthor"); 
                       z.MapLeftKey("BookId"); 
                       z.MapRightKey("AuthorId"); 
                   });

        }
    }
}