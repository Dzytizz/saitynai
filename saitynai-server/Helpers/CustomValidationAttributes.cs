using System.ComponentModel.DataAnnotations;

namespace saitynai_server.Helpers
{
    public class CustomValidationAttributes
    {
        public class HigherOrEqualInt : ValidationAttribute
        {
            private const string DefaultErrorMessage = "{0} value has to be higher or equal to {1} value.";

            public string OtherProperty { get; private set; }

            public HigherOrEqualInt(string otherProperty) : base(DefaultErrorMessage)
            {
                if(string.IsNullOrEmpty(otherProperty))
                    throw new ArgumentNullException(nameof(otherProperty));

                OtherProperty = otherProperty;
            }

            public override string FormatErrorMessage(string name)
            {
                return string.Format(ErrorMessageString, name, OtherProperty);
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if(value != null)
                {
                    var otherProperty = validationContext.ObjectInstance.GetType().GetProperty(OtherProperty);
                    int otherPropertyValue = (int)otherProperty.GetValue(validationContext.ObjectInstance, null);

                    if((int)value < otherPropertyValue) // custom validation check
                    {
                        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                    }
                }

                return ValidationResult.Success;
            }
        }
    }
}
