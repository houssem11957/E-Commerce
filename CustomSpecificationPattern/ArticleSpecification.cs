using MyAxiaMarket1.DataAccess.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.CustomSpecificationPattern
{
    
    public static class ArticleSpecification
    {
        public async static Task<bool> Specification(ICategoryRepository _repository, int categoryId)
        {
            try
            {
                var res = await _repository.GetCategorieByIdAsync(categoryId);
                return res.Success;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
