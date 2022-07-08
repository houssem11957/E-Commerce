using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.Models
{
    public class Contrat
    {
        public Contrat()
        {
            addedon = DateTime.Now;
            lastModified = DateTime.Now;
            valide = true;
            status = "created";
            
        }
        [Key]
        public int ContractId { get; set; }
        [Required]
        public string ContractNature { get; set; }
        [Required]
        public string fournisseurId { get; set; }
        public string Description { get; set; }
        public string clauses { get; set; }
        [Required]
        public string AdminId { get; set; }
        public string status { get; set; }
        public DateTime startDate { get; set; }
        public DateTime effectiveDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime addedon { get; set; }
        public DateTime lastModified { get; set; }
        public string modifiedBy { get; set; }
        public bool valide { get; set; }
    }
}
