using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }


        public String ImageUrl { get; set; }

        [Required(ErrorMessage = "Vous devez indiquer votre prénom")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Vous devez indiquer votre nom")]
        public String LastName { get; set; }


        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Display(Name = "Password")]
        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        public int? Type { get; set; }
        public int? Cin { get; set; }
        public String Address { get; set; }
        public int? Phone { get; set; }
        public int? Points { get; set; }

        public int? CodePostal { get; set; }
        public int? NbClient { get; set; }
        public String Document { get; set; }
        public int? Etat { get; set; }

    }
}
