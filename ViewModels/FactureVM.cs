using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.ViewModels
{
    public class FactureVM
    {
        [Required]
        public string FactureRef { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal total { get; set; }
        public decimal unitprice { get; set; }
        public int CommandId { get; set; }
        public int quantity { get; set; }
        public int taxes { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
        public DateTime payBefore { get; set; }
        public string fourissuerId { get; set; }
        public string adminId { get; set; }
        public string modifiedBy { get; set; }
        public bool valide { get; set; }
    }
}
