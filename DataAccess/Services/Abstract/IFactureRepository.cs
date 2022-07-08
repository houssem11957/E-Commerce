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
  public  interface IFactureRepository : IRepository<Facture>
    {
        Task<GetManyResult<Facture>> GetFacturesAsync(PagingParameters Parameters);
        // done
        Task<GetOneResult<Facture>> UpdateFactureAsync(Facture Facture, int id);
        Task<GetOneResult<Facture>> GetFactureByIdAsync(int id);
        // done
        Task<GetOneResult<Facture>> FindByTitle(string title);

        //done
        Task<GetOneResult<Facture>> UpdateIsActivedAsync(bool IsActive, int id);
        // done
        Task<GetOneResult<Facture>> UpdatestatusAsync(string status, int id);
        //done
        Task<GetManyResult<Facture>> FindInDescriptionAsync(string description);

        //done
        Task<GetOneResult<Facture>> RemoveByIdAsync(int Facture);

        // done
        Task<GetManyResult<Facture>> GetsByStatusAsync(PagingParameters Parameters, string status);
        
        Task<GetManyResult<Facture>> GetsByValidFactureAsync(PagingParameters Parameters, bool isValid);
    }
}
