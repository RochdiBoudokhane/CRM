using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class SuperUserCRM
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Vous devez indiquer votre prénom")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Vous devez indiquer votre nom")]
        public String LastName { get; set; }


        public String Address { get; set; }

        [MinLength(8)]
        public int? Phone { get; set; }
        public int? Cin { get; set; }
        public int? Points { get; set; }
        public int? Type { get; set; }


        [DataType(DataType.ImageUrl)]
        public String ImageUrl { get; set; }



        [Display(Name = "Mot de Passe")]
        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        public String Password { get; set; }


        [Required]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
    }
}