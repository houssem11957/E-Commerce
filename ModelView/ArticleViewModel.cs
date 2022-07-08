using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.ModelView
{
    public class ArticleViewModel
    {
        [Required]
        public string NomArticle { get; set; }
        [Required]
        public string Reference { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        [Required]
        public int cateogryId { get; set; }
        public DateTime addedon { get; set; }
        public DateTime lastModified { get; set; }

        public string modifiedBy { get; set; }
        public bool valide { get; set; }

        public string status { get; set; }
    }
}
