using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket.ViewModels
{
    public class BoutiqueViewModel
    {
        public BoutiqueViewModel()
        {
          
        }
        [Required]
        public string NomBoutique { get; set; }
        public string NatureBoutique { get; set; }
  
        public string Description { get; set; }
        public bool valide { get; set; }
        public string status { get; set; }
        [Required]
        public string modifiedBy { get; set; }
        public string ManagerId { get; set; }
    }
}
