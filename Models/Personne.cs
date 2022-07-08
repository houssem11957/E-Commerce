using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket.Models
{
    public class Personne : IdentityUser
    {
        [StringLength(50, ErrorMessage = "veuillez entrer un mot de passe fort", MinimumLength = 3)]
        [Required(ErrorMessage = "Le nom ne peut pas être vide")]
        public  string NomP { get; set; }
        [StringLength(50, ErrorMessage = "veuillez entrer un mot de passe fort", MinimumLength = 3)]
        [Required(ErrorMessage = "Le nom ne peut pas être vide")]
        public string PrenomP { get; set; } 
        public  string AdresseP { get; set; }
        public  int? TelephoneP { get; set; }
        public bool valide { get; set; }
    }
}
