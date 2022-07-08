﻿using MyAxiaMarket.Models;
using MyAxiaMarket1.DataAccess.Abstract;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.DataAccess.Services.Abstract
{
  public   interface IArticleRepository : IRepository<Article>
    {
         //done
        Task<GetManyResult<Article>> GetArticlesAsync(PagingParameters Parameters);
        // done
        Task<GetOneResult<Article>> UpdateArticleAsync(Article Article, int id);
        Task<GetOneResult<Article>> GetArticleByIdAsync(int id);
        // done
        Task<GetOneResult<Article>> FindByTitle(string title);
        
        //done
        Task<GetOneResult<Article>> UpdateIsActivedAsync(bool IsActive, int id);
        // done
        Task<GetOneResult<Article>> UpdatestatusAsync(string status, int id);
        //done
        Task<GetManyResult<Article>> FindInDescriptionAsync(string description);
     
        //done
        Task<GetOneResult<Article>> RemoveByIdAsync(int Article);

      // done
        Task<GetManyResult<Article>> GetsByStatusAsync(PagingParameters Parameters, string status);
        Task<GetManyResult<Article>> GetsByPriceAsync(PagingParameters Parameters, decimal price);
       // done

        Task<GetManyResult<Article>> GetsByCategoryAsync(PagingParameters Parameters, int category);
        Task<GetManyResult<Article>> GetsByRefArticleAsync(PagingParameters Parameters, string Reference);
       
      
        // done
        Task<GetManyResult<Article>> GetsByvalideAsync(PagingParameters Parameters, bool valide);
       
       
    }
}
