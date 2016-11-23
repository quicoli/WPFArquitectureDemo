using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JulMar.Windows.Mvvm;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace WPFSimpleDemo.Model
{

    public class BaseModel<T> : ViewModel, IEditableObject, IDataErrorInfo
    {

        /// <summary>
        /// Utilizado para manter o estado do objeto antes de sofrer alguma
        /// alteração
        /// </summary>
        private HybridDictionary _oldState;

        protected ValidationResults _validationResults;

       
        public ValidationResults ValidationResults
        { get { return _validationResults; } set { _validationResults = value; } }

        private bool _isValid;

        public BaseModel()
        {
          UpdateValidationState();
        }

        protected override void OnPropertyChanged<T1>(Expression<Func<T1>> propExpr)
        {
            base.OnPropertyChanged(propExpr);
            UpdateValidationState();
            IsValid = _validationResults.IsValid;
        }
        public void UpdateValidationState()
        {
            Validator<T> validator = ValidationFactory.CreateValidator<T>();
            _validationResults = validator.Validate(this);
            IsValid = _validationResults.IsValid;
        }

        public void ClearValidationState()
        {
            _validationResults = new ValidationResults();
            IsValid = true;
        }

        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                base.OnPropertyChanged(() => IsValid);
            }
        }


        /// <summary>
        /// Deve ser chamado antes de se efetuar alguma alteração no
        /// objeto
        /// </summary>
        /// <para>
        /// Exemplo:
        /// </para>
        /// <code>
        /// <example>
        /// var obj = new ObjetoQueImplementaBindableEditabelEntity();
        /// obj.BeginEdit()
        /// obj.Nome = "Teste";
        /// </example>
        /// </code>
        /// <remarks>
        /// Para finalizar a edição dos dados do objeto usa-se <see cref="EndEdit"/>
        /// Para cancelar a edição dos dados do objeto usa-se <see cref="CancelEdit"/>
        /// </remarks>
        public virtual void BeginEdit()
        {
            _oldState = new HybridDictionary();
            foreach (PropertyInfo property in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanWrite)
                {
                    _oldState[property.Name] = property.GetValue(this, null);
                }
            }
        }



        public virtual void EndEdit()
        {
            _oldState = null;
           
        }

        public virtual void CancelEdit()
        {
            if (_oldState == null) return;

            foreach (PropertyInfo property in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanWrite)
                {
                    property.SetValue(this, _oldState[property.Name], null);
                    base.OnPropertyChanged(property.Name);
                }
            }
            _oldState = null;
            UpdateValidationState();

        }

        public virtual string this[string columnName]
        {
            get
            {
                string message = null;
                var filteredResults = new ValidationResults();

                var result = _validationResults.FirstOrDefault(x => x.Key == columnName);
                if (result != null)
                {
                    filteredResults.AddResult(result);
                    message = filteredResults.First().Message;

                }
                return message;
            }
        }

        public virtual string Error
        {
            get { return null; }
        }
    }
}