using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TEST2.Models.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IsPeselCorrect : ValidationAttribute, IClientModelValidator
    {
        public string ComparePropertyName { get; private set; }

        public IsPeselCorrect(string comparePropertyName)
        {
            ComparePropertyName = comparePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var comparePropertyValue = validationContext.ObjectType.GetProperty(ComparePropertyName).GetValue(validationContext.ObjectInstance);

            string errorMessage;
            string pesel;
            string dateFromPesel;
            string dateOfBirth;
            string chengedDateOfBirth;

            /*
             if (value == null)
             {
                 return ValidationResult.Success;
             }
            */
             if (validationContext.DisplayName == null)
             {
                 errorMessage = "The pesel number does not match to the date of birth.";
             }
             else
             {
                 errorMessage = FormatErrorMessage(validationContext.DisplayName);
             }
             

            if (value is long)
            {
                pesel = value.ToString();
            }
            else
            {
                return new ValidationResult("The field type is not 'LONG'.");
            }

            if (comparePropertyValue is DateTime)
            {
                dateOfBirth = comparePropertyValue.ToString();
            }
            else
            {
                return new ValidationResult("The field type is not 'DATE'.");
            }
            
            if (pesel.Length != 11)
            {
                return new ValidationResult(errorMessage);
            }
            


            dateFromPesel = pesel.Substring(0, 2) + "-" + pesel.Substring(2, 2) + "-" + pesel.Substring(4, 2);
            if (dateFromPesel.Length != 8)
            {
                return new ValidationResult("Date from Pesel do not contain 6 character: "+ dateFromPesel);
            }

            chengedDateOfBirth = dateOfBirth.Substring(8, 2) + "-" + dateOfBirth.Substring(3, 2) + "-" + dateOfBirth.Substring(0, 2);
            if (chengedDateOfBirth.Length != 8)
            {
                return new ValidationResult("Date from DateOfBirth do not contain 6 character: " + chengedDateOfBirth);
            }

            if (dateFromPesel != chengedDateOfBirth)
            {
                return new ValidationResult("Pesel is not equal with DateOfBirth, date from Pesel: "+ dateFromPesel+" , "+ chengedDateOfBirth);
            }


            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            MergeAttribute(context.Attributes, "data-val-beforthan", errorMessage);
            MergeAttribute(context.Attributes, "data-val-beforthan-other", ComparePropertyName);
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
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
