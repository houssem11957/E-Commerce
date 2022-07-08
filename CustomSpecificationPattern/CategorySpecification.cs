using MyAxiaMarket1.DataAccess.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.CustomSpecificationPattern
{
    public static  class CategorySpecification
    {
        public async static Task<bool> Specification(IBoutiqueRepository _repository,int boutiqueId)
        {
            try
            {
                var res = await _repository.GetBoutiqueByIdAsync(boutiqueId);
                return res.Success ;

            }catch(Exception e)
            {
                return false;
            }  
        }
    }
}
