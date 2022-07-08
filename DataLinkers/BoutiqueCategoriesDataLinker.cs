using MyAxiaMarket1.DataAccess.Services.Abstract;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.DataLinkers
{
    public static class BoutiqueCategoriesDataLinker
    {
        public async static Task<GetOneResult<BoutiqueCategorieVM>>  Link(IBoutiqueRepository _boutiqueRepository,ICategoryRepository _categoryRepository, int id)
        {
            var restoreturn = new GetOneResult<BoutiqueCategorieVM>();
            var res =await  _boutiqueRepository.GetBoutiqueByIdAsync(id);
            if(res != null)
            {
                restoreturn.Entity._boutique = res.Entity;

                
            }
            return restoreturn;
        }
    }
}
