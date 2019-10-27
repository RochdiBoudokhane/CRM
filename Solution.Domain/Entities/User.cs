using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class User
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

       /* public virtual ICollection<Claim> Claims { get; set; }
        [ForeignKey("ClaimsFK")]
        public virtual Claim  Claim { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        [ForeignKey("PostFK")]
        public virtual Post Post { get; set; }*/

    }
}
