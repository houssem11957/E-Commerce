using MyAxiaMarket1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket.Models
{
    public class Article
    {
        public Article()
        {
            addedon = DateTime.Now;
            lastModified = DateTime.Now;
            valide = true;
            status = "creaed";
            price = 0;
        }
        [Key]
        public int IdArticle { get; set; }
        [Required]
        public string NomArticle { get; set; }
        public string Reference { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public int categoryId { get; set; }
        public DateTime addedon { get; set; }
        public DateTime lastModified { get; set; }
        public string modifiedBy { get; set; }
        public bool valide { get; set; }

        public string status { get; set; }
    }
}
