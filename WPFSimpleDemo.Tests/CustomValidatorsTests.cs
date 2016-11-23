using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NUnit.Framework;
using WPFSimpleDemo.Validation;

namespace WPFSimpleDemo.Tests
{
    [TestFixture]
    public class CustomValidatorsTests
    {
        [Test]
        public void DefaultPasswordRuleIsOk()
        {
            var validator = new DefaultPasswordRule();
            Assert.IsTrue(validator.Passed("A01u03t05v06z07"), "didnt acept valid password");
            Assert.IsFalse(validator.Passed("asefgrgvvv"), "acepted invalid password");
            Assert.IsFalse(validator.Passed(""), "acepted empty password");
        }
    }
}
