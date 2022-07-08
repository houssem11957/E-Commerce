using MyAxiaMarket1.DataAccess.Services.Abstract;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.DataLinkers
{
    public class CategoryArticleDataLinker
    {
        
            public async static Task<GetOneResult<CategoryArticleVM>> Link(IArticleRepository _articleRepository, ICategoryRepository _categoryRepository, int id)
            {
                var restoreturn = new GetOneResult<CategoryArticleVM>();
                var res = await _categoryRepository.GetCategorieByIdAsync(id);
                if (res != null)
                {
               
                }
                return restoreturn;
            }
        
    }
}
