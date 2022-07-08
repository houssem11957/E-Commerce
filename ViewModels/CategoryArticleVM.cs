using MyAxiaMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.ViewModels
{
    public class CategoryArticleVM
    {
        public CategoryArticleVM()
        {
            _articles = new List<Article>();
        }
        public Categorie _categories { get; set; }
        public List<Article> _articles { get; set; }
    }
   
}
