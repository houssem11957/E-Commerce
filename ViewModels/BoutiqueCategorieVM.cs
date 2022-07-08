using MyAxiaMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.ViewModels
{
    public class BoutiqueCategorieVM
    {
        public BoutiqueCategorieVM()
        {
            List<Categorie> _categories = new List<Categorie>();
        }
        public Boutique _boutique { get; set; }
        public List<Categorie> _categories { get; set; }
    }
}
