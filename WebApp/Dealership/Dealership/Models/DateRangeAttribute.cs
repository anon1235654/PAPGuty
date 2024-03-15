using System.ComponentModel.DataAnnotations;

namespace Dealership.Models
{
   
    public class DateRangeAttribute:ValidationAttribute
    {
        private DateTime _minDate;
        private DateTime _maxDate;

        public DateRangeAttribute()
        {
            _minDate = DateTime.Today;
            _maxDate = DateTime.Today.AddYears(10);
            //This works
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            if (value is DateTime dateValue)
            {
                if (dateValue >= _minDate && dateValue <= _maxDate)
                {                      
                        if(dateValue.Day < DateTime.DaysInMonth(dateValue.Year, dateValue.Month))
                        {
                            return ValidationResult.Success;       
                        }
                }
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
