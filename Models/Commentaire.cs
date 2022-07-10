using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.Models
{
    public class Commentaire
    {
        public Commentaire()
        {
            addedon = DateTime.Now;
            lastModified = DateTime.Now;
            valide = true;
            status = "creaed";
        }
        [Key]
        public int IdCommentaire { get; set; }
        [Required]
        public string Title { get; set; }
        public string Family { get; set; }
        public int IdFamily { get; set; }
        public string description { get; set; }
        public DateTime addedon { get; set; }
        public DateTime lastModified { get; set; }
        public string modifiedBy { get; set; }
        public bool valide { get; set; }
        public string status { get; set; }
    }
}
