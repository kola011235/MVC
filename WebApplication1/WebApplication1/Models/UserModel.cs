using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        [Display(Name = "name")]
        [Required(ErrorMessage = "You must enter user name")]
        public string Name { get; set; }
        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "You must enter date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateIfBirth { get; set; }
        [Display(Name = "Age")]
        [Range(0,100,ErrorMessage = "You must enter a valid age")]
        [CorrectAge(ErrorMessage ="Age and date doesn't match")]
        public int Age { get; set; }
    }
}