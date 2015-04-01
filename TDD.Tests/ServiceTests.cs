using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Repositories.Library;
using System.Linq;
using TDD.Entities.Library;
using TDD.Repositories.Library.Stubs;
using System.Data.Entity;
using FakeDbSet;
using System.Collections.Generic;
using Moq;
using TDD.Repositories.Library.Common;
using TDD.Services.Library.IoC;
using Microsoft.Practices.Unity;
using TDD.Services.Library;

namespace TDD.Tests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void T601ServiceGetAllTest()
        {
            //Act
            IUseCaseService service = UnityHelper.Resolve<IUseCaseService>();
            //Arrange
            int c = service.GetAllBooks().Count();
            //Assert
            Assert.AreEqual(2, c);
        }       
    }
}
