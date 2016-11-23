using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSimpleDemo.Validation
{
    /// <summary>
    /// Default password rule verify at least:
    /// 1 - One char is uppercase
    /// 2 - One char is number
    /// 3 - Min. size = 8
    /// </summary>
    public class DefaultPasswordRule: IPasswordRule
    {
        const string ErrorText = "Password must contain at least: 1 Uppercase letter, 1 number and be 8 characters size";
        public bool Passed(string password)
        {
            ErrorMessage = string.Empty;
            
            var isValid = (!string.IsNullOrWhiteSpace(password)) && (password.Any(char.IsUpper) && password.Any(char.IsDigit) && password.Length>=8);
            if (!isValid)
            {
                ErrorMessage = ErrorText;
                return false;
            }
            return true;
        }

        public string ErrorMessage { get; set; }
    }
}
