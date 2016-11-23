using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WPFSimpleDemo.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void CanCreateDatabaseScheema()
        {
            Assert.DoesNotThrow(() =>
            {
                var session = Bootstrapper.Initialize(true);
            });
        }
    }
}
