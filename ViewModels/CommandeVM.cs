using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.ViewModels
{
    public class CommandeVM
    {
        public CommandeVM()
        {
            
        }
        public string commandRefrence { get; set; }
        public string Description { get; set; }
        public string status { get; set; }

        public int boutiqueId { get; set; }
        public int panierId { get; set; }
        public string clientId { get; set; }
        public string TransporterId { get; set; }
        public bool valide { get; set; }
        public string modifiedBy { get; set; }
    }
}
