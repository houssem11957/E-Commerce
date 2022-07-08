using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket.ViewModels
{
    public class CategorieViewModel
    {
        [Required]
        public string NomCategorie { get; set; }
        public string Description { get; set; }
        [Required]
        public int boutiqueId { get; set; }
        public bool valide { get; set; }
        [Required]
        public string modifiedBy { get; set; }
        public string status { get; set; }
    }
}
