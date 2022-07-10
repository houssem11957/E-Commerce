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
    public class ModeDePaiementRepository : Repository<ModeDePaiement>, IModeDePaiementRepository
    {
        private readonly Context _context;
        private DbSet<ModeDePaiement> _Table;
        public ModeDePaiementRepository(DbContextOptions<Context> options) : base(options)
        {
            _context = new Context(options);
            _Table = _context.Set<ModeDePaiement>();
        }

        public async Task<GetOneResult<ModeDePaiement>> FindByTitle(string nomMDP)
        {
            var result = new GetOneResult<ModeDePaiement>();
            if (!string.IsNullOrEmpty(nomMDP))
            {
                try
                {
                    var res = await _Table.Where(x => x.RefModeDepaiement == nomMDP).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<ModeDePaiement>> FindInDescriptionAsync(string description)
        {
            var result = new GetManyResult<ModeDePaiement>();
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

        public async Task<GetOneResult<ModeDePaiement>> GetModeDePaiementByIdAsync(int id)
        {

            var result = new GetOneResult<ModeDePaiement>();
            try
            {
                var cres = await FindAll().Where(temp => temp.IdMdP == id).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<ModeDePaiement>> GetModeDePaiementsAsync(PagingParameters Parameters)
        {
            var result = new GetManyResult<ModeDePaiement>();
            try
            {
                var cres = await FindAll()

               .OrderBy(temp => temp.RefModeDepaiement)
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

        public Task<GetManyResult<ModeDePaiement>> GetsByRefModeDePaiementAsync(PagingParameters Parameters, string Reference)
        {
            throw new NotImplementedException();
        }

        public async Task<GetManyResult<ModeDePaiement>> GetsByvalideAsync(PagingParameters Parameters, bool valide)
        {
            var result = new GetManyResult<ModeDePaiement>();
            try
            {



                var cres = await FindAll()

                  .OrderBy(temp => temp.RefModeDepaiement)
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

        public async Task<GetOneResult<ModeDePaiement>> RemoveByIdAsync(int modeDePaiement)
        {
            var result = new GetOneResult<ModeDePaiement>();
            if (modeDePaiement > 0)
            {
                try
                {
                    var res = await _Table.FindAsync(modeDePaiement);





                    if (res != null && (res.IdMdP != 0))
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

        public async Task<GetOneResult<ModeDePaiement>> UpdateIsActivedAsync(bool IsActive, int id)
        {
            var result = new GetOneResult<ModeDePaiement>();
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

        public async Task<GetOneResult<ModeDePaiement>> UpdateModeDePaiementAsync(ModeDePaiement modeDePaiement, int id)
        {
            var result = new GetOneResult<ModeDePaiement>() { Success = false, Entity = null, Message = "something went wrong please verify the data and train again later !" };
            if (modeDePaiement != null && id > 0)
            {
                try
                {
                    var tsk = await _Table.FindAsync(id);
                    if (tsk != null)
                    {
                        tsk.IdMdP = tsk.IdMdP;
                        tsk.description = modeDePaiement.description;
                        tsk.RefModeDepaiement = modeDePaiement.RefModeDepaiement;
                        tsk.lastModified = modeDePaiement.lastModified;
                        tsk.lastModified = DateTime.Now;
                        tsk.modifiedBy = modeDePaiement.modifiedBy;
                        
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
    }
}
