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
    public interface IModeDePaiementRepository : IRepository<ModeDePaiement>
    {
        //done
        Task<GetManyResult<ModeDePaiement>> GetModeDePaiementsAsync(PagingParameters Parameters);
        // done
        Task<GetOneResult<ModeDePaiement>> UpdateModeDePaiementAsync(ModeDePaiement ModeDePaiement, int id);
        Task<GetOneResult<ModeDePaiement>> GetModeDePaiementByIdAsync(int id);
        // done
        Task<GetOneResult<ModeDePaiement>> FindByTitle(string title);

        //done
        Task<GetOneResult<ModeDePaiement>> UpdateIsActivedAsync(bool IsActive, int id);
        //done
        Task<GetManyResult<ModeDePaiement>> FindInDescriptionAsync(string description);

        //done
        Task<GetOneResult<ModeDePaiement>> RemoveByIdAsync(int ModeDePaiement);

        Task<GetManyResult<ModeDePaiement>> GetsByRefModeDePaiementAsync(PagingParameters Parameters, string Reference);


        // done
        Task<GetManyResult<ModeDePaiement>> GetsByvalideAsync(PagingParameters Parameters, bool valide);


    }
}
