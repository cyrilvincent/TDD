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
    public class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration(string schema = "dbo.")
        {
            ToTable(schema + "Author");
            HasKey(x => x.Id);
            Property(x => x.LastName).IsRequired().HasMaxLength(200);
            Property(x => x.FirstName).IsOptional().HasMaxLength(200);

            Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}