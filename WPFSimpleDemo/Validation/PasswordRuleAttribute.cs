using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;

namespace WPFSimpleDemo.Validation
{
    public class PasswordRuleAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var validator = ServiceLocator.Current.GetInstance<IPasswordRule>();
            var str = value == null ? string.Empty : (string) value;
            var isValid = validator.Passed(str);
            ErrorMessage = validator.ErrorMessage;
            return isValid;
        }
    }
}
