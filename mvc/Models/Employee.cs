using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using mvc.DataAccessLayer;

namespace mvc.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        //[Required(ErrorMessage ="Enter First Name")]
        [FirstNameValidation]
        public string FirstName { get; set; }

        [StringLength(5,ErrorMessage ="Last Name length sould not be greater than 5")]
        public string LastName { get; set; }
        public int? Salary{ get; set; }
    }

    public class FirstNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            if (value == null)
            {
                return new ValidationResult("please provide First Name");
            }else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("First Name sould contain @");
                }
            }
            return ValidationResult.Success;
        }
    }
}