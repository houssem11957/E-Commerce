using MyAxiaMarket.Models;
using MyAxiaMarket1.DataAccess.Abstract;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.DataAccess.Services.Abstract
{
    public interface ICategoryRepository : IRepository<Categorie>
    {
        //done
        Task<GetManyResult<Categorie>> GetCategoriesAsync(PagingParameters Parameters);
        // done
        Task<GetOneResult<Categorie>> UpdateCategorieAsync(Categorie Categorie, int id);
        Task<GetOneResult<Categorie>> GetCategorieByIdAsync(int id);
        // done
        Task<GetOneResult<Categorie>> FindByTitle(string title);

        //done
        Task<GetOneResult<Categorie>> UpdateIsActivedAsync(bool IsActive, int id);
        // done
        Task<GetOneResult<Categorie>> UpdatestatusAsync(string status, int id);
        //done
        Task<GetManyResult<Categorie>> FindInDescriptionAsync(string description);

        //done
        Task<GetOneResult<Categorie>> RemoveByIdAsync(int Categorie);

        // done
        Task<GetManyResult<Categorie>> GetsByStatusAsync(PagingParameters Parameters, string status);
        // done
        Task<GetManyResult<Categorie>> GetsByNomCategorieAsync(PagingParameters Parameters, string nomCategorie);
        // done
      
        // done
        Task<GetManyResult<Categorie>> GetsByvalideAsync(PagingParameters Parameters, bool valide);
        // done
       
    }
}
