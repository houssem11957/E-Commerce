using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MyAxiaMarket1.ViewModels
{
   
        public class LoginViewModel
        {
            [Required(ErrorMessage = "L'e-mail ne peut pas être vide")]
            [EmailAddress(ErrorMessage = "veuillez entrer une adresse e-mail correcte")]
            public string email { get; set; }
            [Required(ErrorMessage = "Le mot de passe ne peut pas être vide")]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "mot de passe non valide")]
            public string password { get; set; }

        }
    
}
