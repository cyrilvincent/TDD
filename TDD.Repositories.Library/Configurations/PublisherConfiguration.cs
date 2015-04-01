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
    public class PublisherConfiguration : EntityTypeConfiguration<Publisher>
    {
        public PublisherConfiguration(string schema = "dbo.")
        {
            ToTable(schema + "Publisher");
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(200);

            Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}