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
public  interface IBoutiqueRepository : IRepository<Boutique>
    {
        Task<GetManyResult<Boutique>> GetLatestBoutiques(int numberOfRecord);
        Task<GetOneResult<Boutique>> UpdateIsActivedAsync(bool IsActive, int id);
        Task<GetOneResult<Boutique>> UpdatestatusAsync(string status, int id);
        Task<GetOneResult<Boutique>> UpdateBoutiqueAsync(Boutique boutique, int id);
        Task<GetOneResult<Boutique>> RemoveByIdAsync(int boutiqueId);
        Task<GetManyResult<Boutique>> GetsByStatusAsync(PagingParameters Parameters, string status);
        Task<GetManyResult<Boutique>> GetsByNomBoutiqueAsync(PagingParameters Parameters, string NomBoutique);
        Task<GetManyResult<Boutique>> GetsByNatureBoutiqueAsync(PagingParameters Parameters, string natureBoutique);
        Task<GetManyResult<Boutique>> GetsByvalideAsync(PagingParameters Parameters, bool valide);
        Task<GetManyResult<Boutique>> GetsByManagerIdAsync(PagingParameters Parameters, string ManagerId);
        Task<GetManyResult<Boutique>> GetBoutiquesAsync(PagingParameters Parameters);
        Task<GetOneResult<Boutique>> GetBoutiqueByIdAsync(int id);

    }
}
