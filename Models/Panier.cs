using MyAxiaMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.Models
{
    public class Panier
    {
        public Panier()
        {
            addedon = DateTime.Now;
            lastModified = DateTime.Now;
            valide = true;
            status = "created";
        }
        [Key]
        public int PanierId { get; set; }
        public string NomPanier { get; set; }
        public string Reference { get; set; }
        public string status { get; set; }
        public string visitorId { get; set; }
        public string Articles { get; set; }
        public string description { get; set; }
        public DateTime addedon { get; set; }
        public DateTime lastModified { get; set; }
        public int modifiedBy { get; set; }
        public bool valide { get; set; }

        
        
    }
}
