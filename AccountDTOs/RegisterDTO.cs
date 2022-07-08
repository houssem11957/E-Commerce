using MyAxiaMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MyAxiaMarket1.AccountDTOs
{
    public class PersonneDTO
    {
        [StringLength(50, ErrorMessage = "longueur invalide", MinimumLength = 3)]
        [Required(ErrorMessage = "Le role ne peut pas être vide")]
        public string role { get; set; }
        [StringLength(50, ErrorMessage = "longueur invalide", MinimumLength = 6)]
        [Required(ErrorMessage = "Le role ne peut pas être vide")]
        public string password { get; set; }

        public string userName { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }

       
    }
    public class AdminDTO
    {
        
        [StringLength(50, ErrorMessage = "longueur invalide", MinimumLength = 6)]
        [Required(ErrorMessage = "Le role ne peut pas être vide")]
        public string password { get; set; }

        public string userName { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }


    }
}
