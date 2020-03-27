using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelMetadata = Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata;

namespace Pras.Shared.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class RequiredIfNotAttribute : ValidationAttribute, IClientModelValidator
    {
        //Сообщение, которое будет выводиться пользователю.
        private const string DefaultErrorMessage = "{0} is required";

        //Целевое поле
        private readonly string _targetPropertyName;
        //Значение целевого поля
        private readonly string _targetPropertyCondition;

        public RequiredIfNotAttribute(string targetPropertyName, string targetPropertyCondition)
            : base(DefaultErrorMessage)
        {
            _targetPropertyName = targetPropertyName;
            _targetPropertyCondition = !String.IsNullOrEmpty(targetPropertyCondition)
                ? targetPropertyCondition
                : null;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString, name, _targetPropertyName,
                _targetPropertyCondition);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool propertyRequired = false; // Флаг для проверки обязательности заполнения текущего поля.

            //Получим целевое поле
            var targetProperty = validationContext.ObjectType.GetProperty(_targetPropertyName);

            //Получим значние целевого поля
            var targetPropertyValue = targetProperty.GetValue(validationContext.ObjectInstance, null);
            targetPropertyValue = (targetPropertyValue == null) ? null : targetPropertyValue.ToString();

            //Если значение целевого поля соответствует заданному, то текущее поле должно быть заполнено.
            if ((string) targetPropertyValue != _targetPropertyCondition)
            {
                propertyRequired = true;
            }

            if (propertyRequired)
            {
                //Если поле не заполнено
                if (value == null)
                {
                    var message = FormatErrorMessage(validationContext.DisplayName);

                    return new ValidationResult(message);
                }
            }

            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
            ClientModelValidationContext context)
        {
            var rule = new ModelClientValidationRule();

            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationType = "requiredifnot";
            rule.ValidationParameters.Add("targetpropertyname", _targetPropertyName);
            rule.ValidationParameters.Add("targetpropertyvalue", _targetPropertyCondition ?? "");

            yield return rule;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-requiredifnot-targetpropertyname", _targetPropertyName);
            MergeAttribute(context.Attributes, "data-val-requiredifnot-targetpropertyvalue", _targetPropertyCondition ?? "");
            var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            MergeAttribute(context.Attributes, "data-val-requiredifnot", errorMessage);
        }

        private bool MergeAttribute(IDictionary<string, string> attributes,
            string key,
            string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }
    }
}