using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket.Models
{
    public class Categorie
    {
        public Categorie()
        {
            addedon = DateTime.Now;
            lastModified = DateTime.Now;
            valide = true;
            status = "created";
           
        }
        [Key]
        public int IdCategorie { get; set; }
        [Required]
        public string NomCategorie { get; set; }
        public string Description { get; set; }
        public bool valide { get; set; }
        public DateTime addedon { get; set; }
        public DateTime lastModified { get; set; }
        public string modifiedBy { get; set; }

        public int boutiqueId { get; set; }
        public string status { get; set; }

        
        
        
    }
}
