using Microsoft.EntityFrameworkCore;
using MyAxiaMarket.Data;
using MyAxiaMarket1.DataAccess.Concrete;
using MyAxiaMarket1.DataAccess.Services.Abstract;
using MyAxiaMarket1.Models;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.DataAccess.Services.Concrete
{
    public class CommentaireRepository : Repository<Commentaire>, ICommentaireRepository
    {
        private readonly Context _context;
        private DbSet<Commentaire> _Table;
        public CommentaireRepository(DbContextOptions<Context> options) : base(options)
        {
            _context = new Context(options);
            _Table = _context.Set<Commentaire>();
        }

        public async Task<GetOneResult<Commentaire>> FindByTitle(string title)
        {
            var result = new GetOneResult<Commentaire>();
            if (!string.IsNullOrEmpty(title))
            {
                try
                {
                    var res = await _Table.Where(x => x.Title == title).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<Commentaire>> FindInDescriptionAsync(string description)
        {
            var result = new GetManyResult<Commentaire>();
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

        public async Task<GetOneResult<Commentaire>> GetCommentaireByIdAsync(int id)
        {
            var result = new GetOneResult<Commentaire>();
            try
            {
                var cres = await FindAll().Where(temp => temp.IdCommentaire == id).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<Commentaire>> GetCommentairesAsync(PagingParameters Parameters)
        {
            var result = new GetManyResult<Commentaire>();
            try
            {
                var cres = await FindAll()

               .OrderBy(temp => temp.Title)
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

        public async Task<GetManyResult<Commentaire>> GetsByRefCommentaireAsync(PagingParameters Parameters, string Reference)
        {
            var result = new GetManyResult<Commentaire>();
            if (!string.IsNullOrEmpty(Reference))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.Title == Reference).ToListAsync();
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

        public async Task<GetManyResult<Commentaire>> GetsByvalideAsync(PagingParameters Parameters, bool valide)
        {
            var result = new GetManyResult<Commentaire>();
            try
            {



                var cres = await FindAll()

                  .OrderBy(temp => temp.Title)
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

        public async Task<GetOneResult<Commentaire>> RemoveByIdAsync(int Commentaire)
        {
            var result = new GetOneResult<Commentaire>();
            if (Commentaire > 0)
            {
                try
                {
                    var res = await _Table.FindAsync(Commentaire);





                    if (res != null && (res.IdCommentaire != 0))
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
        public  async Task<GetOneResult<Commentaire>> UpdateCommentaireAsync(Commentaire Commentaire, int id)
        {
            var result = new GetOneResult<Commentaire>() { Success = false, Entity = null, Message = "something went wrong please verify the data and train again later !" };
            if (Commentaire != null && id > 0)
            {
                try
                {
                    var tsk = await _Table.FindAsync(id);
                    if (tsk != null)
                    {
                        tsk.IdCommentaire = tsk.IdCommentaire;
                        tsk.description = Commentaire.description;
                        tsk.Title = Commentaire.Title;
                        tsk.lastModified = Commentaire.lastModified;
                        tsk.lastModified = DateTime.Now;
                        tsk.modifiedBy = Commentaire.modifiedBy;

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

        public async Task<GetOneResult<Commentaire>> UpdateIsActivedAsync(bool IsActive, int id)
        {
            var result = new GetOneResult<Commentaire>();
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
    }
}
