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
public interface ICommandeRepository : IRepository<Commande>
    {
        Task<GetManyResult<Commande>> GetCommandesAsync(PagingParameters Parameters);
        // done
        Task<GetOneResult<Commande>> UpdateCommandeAsync(Commande Commande, int id);
        Task<GetOneResult<Commande>> GetCommandeByIdAsync(int id);
        // done
        Task<GetOneResult<Commande>> FindByTitle(string title);

        //done
        Task<GetOneResult<Commande>> UpdateIsActivedAsync(bool IsActive, int id);
        // done
        Task<GetOneResult<Commande>> UpdatestatusAsync(string status, int id);
        //done
        Task<GetManyResult<Commande>> FindInDescriptionAsync(string description);

        //done
        Task<GetOneResult<Commande>> RemoveByIdAsync(int Commande);

        // done
        Task<GetManyResult<Commande>> GetsByStatusAsync(PagingParameters Parameters, string status);
      
        // done

        Task<GetManyResult<Commande>> GetsByCategoryAsync(PagingParameters Parameters, int category);
       
        Task<GetOneResult<Commande>> GetsByRefCommandeAsync(PagingParameters Parameters, string Reference);


        // done
        Task<GetManyResult<Commande>> GetsByvalideAsync(PagingParameters Parameters, bool valide);
    }
}
