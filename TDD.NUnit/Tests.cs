using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.NUnit
{
    [TestFixture]
    public class Tests
    {
        // Nécessite VSTestAdapter http://nunit.org/index.php?p=vsTestAdapter&r=2.6.2
        // Outils / Extensions et MAJ / NUnit
        [Test]
        public void T000MyFirstNUnitTest()
        {
            int i = 1;
            int j = 2;
            int k = i + j;
            Assert.AreEqual(k, 3);
        }
    }
}
