using MyAxiaMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket.Services
{
    public interface IDataService
    {
        Task<Personne> GetPersonneAsync();
        Task<Boutique> GetBoutiqueAsync();
        Task<Categorie> GetCategorieAsync();
        Task<Article> GetArticleAsync();

    }
}

