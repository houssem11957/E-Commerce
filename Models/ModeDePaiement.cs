using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.Models
{
    public class ModeDePaiement
    {
        public ModeDePaiement()
        {

        }
        [Key]
        public int IdMdP { get; set; }
        [Required]
        public string RefModeDepaiement { get; set; }
        public string description { get; set; }
        public DateTime addedon { get; set; }
        public DateTime lastModified { get; set; }
        public string modifiedBy { get; set; }
        public bool valide { get; set; }

       
    }
}
