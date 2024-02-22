using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using NET.Models.Validations;

namespace NET.Models
{
    public class StuentModel
    {
        // public StuentModel(int id, string name, int standard, string gender, string mail)
        // {
        //     ID = id; Name = name; Standard = standard; Gender = gender; Email = mail;
        // }
        [Required]


        public int ID { get; set; }
        [Required]
        [DataType("String")]
        [DisplayName("Student's Full Name")]

        public string? Name { get; set; }
        [Required]
        public int Standard { get; set; }
        [StuentValidation]
        [AllowedValues("Female", "Male")]
        public string Gender { get; set; }

        [EmailValidation]

        public string Email { get; set; }

        // public StuentModel(int id, string name, int standard, string gender, string mail)
        // {
        //     ID = id; Name = name; Standard = standard; Gender = gender; Email = mail;
        // }



        public override string ToString()
        {


            return $"{ID} {Name} {Standard} {Gender}";

        }
        // public override string ToString()
        // {
        //     return "Person: " + Name + " " + Age;
        // }




    }

}

