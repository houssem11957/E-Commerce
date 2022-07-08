using MyAxiaMarket1.DataAccess.Abstract;
using MyAxiaMarket1.Models;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.DataAccess.Services.Abstract
{
  public interface IPanierRepository : IRepository<Panier>
    {
        Task<GetManyResult<Panier>> GetPaniersAsync(PagingParameters Parameters);
        // done
        Task<GetOneResult<Panier>> UpdatePanierAsync(Panier Panier, int id);
        Task<GetOneResult<Panier>> GetPanierByIdAsync(int id);
        // done
        Task<GetOneResult<Panier>> FindByTitle(string title);

        //done
        Task<GetOneResult<Panier>> UpdateIsActivedAsync(bool IsActive, int id);
        // done
        Task<GetOneResult<Panier>> UpdatestatusAsync(string status, int id);
        //done
        Task<GetManyResult<Panier>> FindInDescriptionAsync(string description);

        //done
        Task<GetOneResult<Panier>> RemoveByIdAsync(int Panier);

        // done
        Task<GetManyResult<Panier>> GetsByStatusAsync(PagingParameters Parameters, string status);

        Task<GetManyResult<Panier>> GetsByValidPanierAsync(PagingParameters Parameters, bool isValid);
    }
}
