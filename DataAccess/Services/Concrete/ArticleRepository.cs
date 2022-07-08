using Microsoft.EntityFrameworkCore;
using MyAxiaMarket.Data;
using MyAxiaMarket.Models;
using MyAxiaMarket1.DataAccess.Concrete;
using MyAxiaMarket1.DataAccess.Services.Abstract;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.DataAccess.Services.Concrete
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly Context _context;
        private DbSet<Article> _Table;
        public ArticleRepository(DbContextOptions<Context> options) : base(options)
        {
            _context = new Context(options);
            _Table = _context.Set<Article>();
        }

        public async Task<GetOneResult<Article>> FindByTitle(string title)
        {
            var result = new GetOneResult<Article>();
            if (!string.IsNullOrEmpty(title))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.NomArticle == title).FirstOrDefaultAsync();
                    if (res != null)
                    {
                        result.Entity = res;
                        result.Message = "search completed";
                        result.Success = true;
                    }

                }
                catch (Exception exp)
                {
                    result.Entity = null;
                    result.Message = "error occured possible reason :" + exp.Message;
                    result.Success = false;

                }
            }
            return result;
        }

        public async Task<GetManyResult<Article>> FindInDescriptionAsync(string description)
        {
            var result = new GetManyResult<Article>();
            if (!string.IsNullOrEmpty(description))
            {
                try
                {
                    var res = await _Table.Where(temp => description.Any(a => temp.description.Contains(a))).AsQueryable().ToListAsync();
                    if (res.Count > 0)
                    {
                        result.Entity = res;
                        result.Message = "search completed";
                        result.Success = true;
                    }

                }
                catch (Exception exp)
                {
                    result.Entity = null;
                    result.Message = "error occured possible reason :" + exp.Message;
                    result.Success = false;

                }
            }
            return result;
        }

        public async Task<GetOneResult<Article>> GetArticleByIdAsync(int id)
        {
            var result = new GetOneResult<Article>();
            try
            {
                var cres = await FindAll().Where(temp => temp.IdArticle == id).FirstOrDefaultAsync();
                if (cres != null)
                {
                    result.Entity = cres;

                    result.Success = true;
                }

            }
            catch (Exception exp)
            {
                result.Entity = null;
                result.Message = "error occured possible reason :" + exp.Message;
                result.Success = false;

            }
            return result;
        }

        public async Task<GetManyResult<Article>> GetArticlesAsync(PagingParameters Parameters)
        {
            var result = new GetManyResult<Article>();
            try
            {
                var cres = await FindAll()

               .OrderBy(temp => temp.NomArticle)
               .Skip((Parameters.PageNumber - 1) * Parameters.PageSize)
               .Take(Parameters.PageSize).ToListAsync();
                if (cres.Count > 0)
                {
                    result.Entity = cres;
                    result.NumberOfRecords = _Table.Count();
                    result.PageNumber = Parameters.PageNumber;
                    result.Success = true;
                }

            }
            catch (Exception exp)
            {
                result.Entity = null;
                result.Message = "error occured possible reason :" + exp.Message;
                result.Success = false;

            }
            return result;
        }

        public async Task<GetManyResult<Article>> GetsByCategoryAsync(PagingParameters Parameters, int category)
        {
            var result = new GetManyResult<Article>();
            if (category>0)
            {
                try
                {

                    var res = await _Table.Where(temp => temp.categoryId == category).ToListAsync();
                    if(res.Count >0 )
                    {
                        result.Entity = res;
                        result.Success = true;
                        result.Message = "search complete !";
                    }
                }
                catch (Exception exp)
                {
                    result.Entity = null;
                    result.Message = "error occured possible reason :" + exp.Message;
                    result.Success = false;

                }
            }
            return result;
        }

       

       
        

        public async Task<GetManyResult<Article>> GetsByPriceAsync(PagingParameters Parameters, decimal price)
        {
            var result = new GetManyResult<Article>();
            try
            {

            
           
            var cres = await FindAll()

              .OrderBy(temp => temp.price)
              .Where(temp=>temp.price < price)
              .Skip((Parameters.PageNumber - 1) * Parameters.PageSize)
              .Take(Parameters.PageSize).ToListAsync();
            if (cres.Count > 0)
            {
                result.Entity = cres;
                result.NumberOfRecords = _Table.Count();
                result.PageNumber = Parameters.PageNumber;
                result.Success = true;
            }
            }
            catch (Exception exp)
            {
                result.Entity = null;
                result.Message = "error occured possible reason :" + exp.Message;
                result.Success = false;

            }
            return result;
        }
    
            

        public async Task<GetManyResult<Article>> GetsByRefArticleAsync(PagingParameters Parameters, string Reference)
        {
            var result = new GetManyResult<Article>();
            try
            {



                var cres = await FindAll()

                  .OrderBy(temp => temp.price)
                  .Where(temp => temp.Reference == Reference)
                  .Skip((Parameters.PageNumber - 1) * Parameters.PageSize)
                  .Take(Parameters.PageSize).ToListAsync();
                if (cres.Count > 0)
                {
                    result.Entity = cres;
                    result.NumberOfRecords = _Table.Count();
                    result.PageNumber = Parameters.PageNumber;
                    result.Success = true;
                }
            }
            catch (Exception exp)
            {
                result.Entity = null;
                result.Message = "error occured possible reason :" + exp.Message;
                result.Success = false;

            }
            return result;
        }

        public async Task<GetManyResult<Article>> GetsByStatusAsync(PagingParameters Parameters, string status)
        {
            var result = new GetManyResult<Article>();
            try
            {



                var cres = await FindAll()

                  .OrderBy(temp => temp.price)
                  .Where(temp => temp.status == status)
                  .Skip((Parameters.PageNumber - 1) * Parameters.PageSize)
                  .Take(Parameters.PageSize).ToListAsync();
                if (cres.Count > 0)
                {
                    result.Entity = cres;
                    result.NumberOfRecords = _Table.Count();
                    result.PageNumber = Parameters.PageNumber;
                    result.Success = true;
                }
            }
            catch (Exception exp)
            {
                result.Entity = null;
                result.Message = "error occured possible reason :" + exp.Message;
                result.Success = false;

            }
            return result;
        }

        public async Task<GetManyResult<Article>> GetsByvalideAsync(PagingParameters Parameters, bool valide)
        {
            var result = new GetManyResult<Article>();
            try
            {



                var cres = await FindAll()

                  .OrderBy(temp => temp.price)
                  .Where(temp => temp.valide == valide)
                  .Skip((Parameters.PageNumber - 1) * Parameters.PageSize)
                  .Take(Parameters.PageSize).ToListAsync();
                if (cres.Count > 0)
                {
                    result.Entity = cres;
                    result.NumberOfRecords = _Table.Count();
                    result.PageNumber = Parameters.PageNumber;
                    result.Success = true;
                }
            }
            catch (Exception exp)
            {
                result.Entity = null;
                result.Message = "error occured possible reason :" + exp.Message;
                result.Success = false;

            }
            return result;
        }

        public  async Task<GetOneResult<Article>> RemoveByIdAsync(int Article)
        {
            var result = new GetOneResult<Article>();
            if (Article > 0)
            {
                try
                {
                    var res = await _Table.FindAsync(Article);





                    if (res != null && (res.IdArticle != 0))
                    {
                        var myres = _Table.Remove(res);
                        var sc = await _context.SaveChangesAsync();
                        if (sc > 0)
                        {
                            result.Entity = res;
                            result.Message = "Task Removed correctly !";
                            result.Success = true;
                        }

                    }

                }
                catch (Exception exp)
                {
                    result.Entity = null;
                    result.Message = "error occured possible reason :" + exp.Message;
                    result.Success = false;

                }
            }
            return result;
        }

        public async Task<GetOneResult<Article>> UpdateArticleAsync(Article Article, int id)
        {
            var result = new GetOneResult<Article>() { Success = false, Entity = null, Message = "something went wrong please verify the data and train again later !" };
            if (Article != null && id>0)
            {
                try
                {
                    var tsk = await _Table.FindAsync(id);
                    if (tsk != null)
                    {
                        tsk.IdArticle = tsk.IdArticle;
                        tsk.description = Article.description;
                        tsk.NomArticle = Article.NomArticle;
                        tsk.lastModified = Article.lastModified;

                        var res = await _context.SaveChangesAsync();
                        if (res > 0)
                        {
                            result.Entity = tsk;
                            result.Success = true;
                            result.Message = "data updated Successfully ! ";
                        }
                    }


                }
                catch (Exception exp)
                {
                    result.Entity = null;
                    result.Success = false;
                    result.Message = "error occured posssible reason : " + exp.Message;

                }
            }
            return result;
        }

        public async Task<GetOneResult<Article>> UpdateIsActivedAsync(bool IsActive, int id)
        {
            var result = new GetOneResult<Article>();
            if (id > 0)
            {
                try
                {
                    var res = await _Table.FindAsync(id);
                    if (res != null)
                    {
                        res.valide = IsActive;
                        var sv = await _context.SaveChangesAsync();
                        if (sv > 0)
                        {
                            result.Entity = res;
                            result.Success = true;
                        }

                    }
                }
                catch (Exception exp)
                {
                    result.Entity = null;
                    result.Success = false;
                    result.Message = "error occured ,possible reason :" + exp.Message;

                }
            }
            return result;
        }

        public async Task<GetOneResult<Article>> UpdatestatusAsync(string status, int id)
        {
            var result = new GetOneResult<Article>();
            if (id > 0 && ((string.IsNullOrEmpty(status))))
            {
                try
                {
                    var res = await _Table.FindAsync(id);
                    if (res != null)
                    {
                        res.status = status;
                        var sv = await _context.SaveChangesAsync();
                        if (sv > 0)
                        {
                            result.Entity = res;
                            result.Success = true;
                        }

                    }
                }
                catch (Exception exp)
                {
                    result.Entity = null;
                    result.Success = false;
                    result.Message = "error occured ,possible reason :" + exp.Message;

                }
            }
            return result;
        }
    }
}
