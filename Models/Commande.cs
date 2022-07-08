using MyAxiaMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.Models
{
    public class Commande
    {
        public Commande()
        {
            addedon = DateTime.Now;
            lastModified = DateTime.Now;
            valide = true;
            status = "created";
           
         }
        [Key]
        public int CommandId { get; set; }
        [Required]
        public string commandRefrence { get; set; }
        public string Description { get; set; }
        public string status { get; set; }

        public int boutiqueId { get; set; }
        public int panierId { get; set; }
        public string clientId { get; set; }
        public string TransporterId { get; set; }
        public bool valide { get; set; }
        public DateTime addedon { get; set; }
        public DateTime lastModified { get; set; }
        public string modifiedBy { get; set; }
        

    }
}
