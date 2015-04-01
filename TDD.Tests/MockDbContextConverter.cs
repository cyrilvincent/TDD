using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Entities.Library;
using TDD.Repositories.Library;

namespace TDD.Tests
{
    public class MockDbContextConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            IQueryable<Book> data = new List<Book> {
                new Book {Id = 1, Title="TDD"},
                new Book {Id = 2, Title="Moq"},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockWrapperTDDContext = new Mock<TDDDbContext>();
            mockWrapperTDDContext.Setup(c => c.Books).Returns(mockSet.Object);
            mockWrapperTDDContext.Setup(c => c.Set<Book>()).Returns(mockSet.Object);
            return mockWrapperTDDContext.Object;
        }
    }
}
