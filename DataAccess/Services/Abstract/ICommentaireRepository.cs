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
  public   interface ICommentaireRepository : IRepository<Commentaire>
    {
        //done
        Task<GetManyResult<Commentaire>> GetCommentairesAsync(PagingParameters Parameters);
        // done
        Task<GetOneResult<Commentaire>> UpdateCommentaireAsync(Commentaire Commentaire, int id);
        Task<GetOneResult<Commentaire>> GetCommentaireByIdAsync(int id);
        // done
        Task<GetOneResult<Commentaire>> FindByTitle(string title);

        //done
        Task<GetOneResult<Commentaire>> UpdateIsActivedAsync(bool IsActive, int id);
        //done
        Task<GetManyResult<Commentaire>> FindInDescriptionAsync(string description);

        //done
        Task<GetOneResult<Commentaire>> RemoveByIdAsync(int Commentaire);

        Task<GetManyResult<Commentaire>> GetsByRefCommentaireAsync(PagingParameters Parameters, string Reference);


        // done
        Task<GetManyResult<Commentaire>> GetsByvalideAsync(PagingParameters Parameters, bool valide);


    }
}
