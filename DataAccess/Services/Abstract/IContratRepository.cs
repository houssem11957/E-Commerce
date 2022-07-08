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
 public    interface IContratRepository : IRepository<Contrat>
    {
        Task<GetManyResult<Contrat>> GetContratsAsync(PagingParameters Parameters);
        // done
        Task<GetOneResult<Contrat>> UpdateContratAsync(Contrat Contrat, int id);
        Task<GetOneResult<Contrat>> GetContratByIdAsync(int id);
        Task<GetManyResult<Contrat>> GetContratByContractNatureAsync(string nature);
        Task<GetManyResult<Contrat>> GetContratByFournisseurAsync(string fournisseur);
      
 
        //done
        Task<GetOneResult<Contrat>> UpdateIsActivedAsync(bool IsActive, int id);
        // done
        Task<GetOneResult<Contrat>> UpdatestatusAsync(string status, int id);
        //done
        Task<GetManyResult<Contrat>> FindInDescriptionAsync(string description);

        //done
        Task<GetOneResult<Contrat>> RemoveByIdAsync(int Contrat);

        // done
        Task<GetManyResult<Contrat>> GetsByStatusAsync(PagingParameters Parameters, string status);

        // done
        Task<GetManyResult<Contrat>> GetsByvalideAsync(PagingParameters Parameters, bool valide);
    }
}
