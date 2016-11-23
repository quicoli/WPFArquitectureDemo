using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using WPFSimpleDemo.Validation;
using ValidationResult = Microsoft.Practices.EnterpriseLibrary.Validation.ValidationResult;

namespace WPFSimpleDemo.Model
{
    [HasSelfValidation]
    public class UserModel: BaseModel<UserModel>
    {
        private long _id;
        private string _userName;
        private string _password;
        private string _confirmPassword;

        public long Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(()=> Id);}
        }

        [Required(ErrorMessage = "User name is required")]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(()=>UserName); OnPropertyChanged();}
        }

        [PasswordRule]
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(()=>Password); }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; OnPropertyChanged(()=>ConfirmPassword); }
        }


        [SelfValidation]
        public void Validate(ValidationResults validationResults)
        {
            if (string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                validationResults.AddResult(
                        new ValidationResult("Required!", this, "ConfirmPassword", null,null));

            }

            if (ConfirmPassword != Password)
            {
                validationResults.AddResult(
                        new ValidationResult("Confirmation and Password doesn't match!", this, "ConfirmPassword", null, null));
            }
        }
    }
}
