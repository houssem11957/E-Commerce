using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket.Models
{
    public class Boutique
    {
        public Boutique()
        {
            addedon = DateTime.Now;
            lastModified = DateTime.Now;
            valide = true;
            status = "creaed";
           
        }
        [Key]
        public int IdBoutique { get; set; }
        [Required]
        public string NomBoutique { get; set; }
        public string NatureBoutique { get; set; }
        
        public string Description { get; set; }
        public bool valide { get; set; }
        public string status { get; set; }
        public DateTime addedon { get; set; }
        public DateTime lastModified { get; set; }
        public string modifiedBy { get; set; }
        public string ManagerId { get; set; }

        //relationship
      
    }
}
