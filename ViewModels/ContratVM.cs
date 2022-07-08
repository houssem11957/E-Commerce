using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.ViewModels
{
    public class ContratVM
    {
       
        [Required]
        public string ContractNature { get; set; }
        [Required]
        public string fournisseurId { get; set; }
        public string Description { get; set; }
        public string clauses { get; set; }
        [Required]
        public string AdminId { get; set; }
        public string status { get; set; }
        [Required]
        public DateTime startDate { get; set; }
        [Required]
        public DateTime effectiveDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string modifiedBy { get; set; }
        public bool valide { get; set; }
    }
}
