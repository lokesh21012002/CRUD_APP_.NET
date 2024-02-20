using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NET.Models;

namespace NET.Models.Validations
{
    public class StuentValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {

            var studentobj = validationContext.ObjectInstance as StuentModel;
            if (studentobj != null && studentobj.Gender != null)
            {
                if (studentobj.Gender.Equals("Female") && studentobj.Standard > 8)
                {

                    return new ValidationResult("We are not allowing girls greater than standar 8");


                }


            }
            return ValidationResult.Success;


        }




    }
    public class EmailValidation : ValidationAttribute
    {

        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {

            var studentobj = validationContext.ObjectInstance as StuentModel;
            if (studentobj != null && studentobj.Email != null)
            {

                if (isValidEmail(studentobj.Email))
                {
                    return ValidationResult.Success;
                }




            }
            return new ValidationResult("Invalid email");



        }




    }
}