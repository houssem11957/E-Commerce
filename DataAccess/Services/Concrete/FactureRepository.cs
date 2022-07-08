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
    public class FactureRepository : Repository<Facture>, IFactureRepository
    {
        private readonly Context _context;
        private DbSet<Facture> _Table;
        public FactureRepository(DbContextOptions<Context> options) : base(options)
        {
            _context = new Context(options);
            _Table = _context.Set<Facture>();
        }

        public async Task<GetOneResult<Facture>> FindByTitle(string title)
        {
            var result = new GetOneResult<Facture>();
            if (!string.IsNullOrEmpty(title))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.FactureRef == title).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<Facture>> FindInDescriptionAsync(string description)
        {
            var result = new GetManyResult<Facture>();
            if (!string.IsNullOrEmpty(description))
            {
                try
                {
                    var res = await _Table.Where(temp => description.Any(a => temp.Description.Contains(a))).AsQueryable().ToListAsync();
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

        public async Task<GetOneResult<Facture>> GetFactureByIdAsync(int id)
        {
            var result = new GetOneResult<Facture>();
            try
            {
                var cres = await FindAll().Where(temp => temp.FactureId == id).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<Facture>> GetFacturesAsync(PagingParameters Parameters)
        {
            var result = new GetManyResult<Facture>();
            try
            {
                var cres = await FindAll()

               .OrderBy(temp => temp.FactureId)
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

        public async Task<GetManyResult<Facture>> GetsByStatusAsync(PagingParameters Parameters, string status)
        {
            var result = new GetManyResult<Facture>();
            if (!string.IsNullOrEmpty(status))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.status == status).ToListAsync();
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

        public async Task<GetManyResult<Facture>> GetsByValidFactureAsync(PagingParameters Parameters, bool isValid)
        {
            var result = new GetManyResult<Facture>();
            
                try
                {
                    var res = await _Table.Where(temp => temp.valide == isValid).ToListAsync();
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
            
            return result;
        }

        public async Task<GetOneResult<Facture>> RemoveByIdAsync(int Facture)
        {
            var result = new GetOneResult<Facture>();
            if (Facture > 0)
            {
                try
                {
                    var res = await _Table.FindAsync(Facture);
                    if (res != null && (res.FactureId != 0))
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

        public async Task<GetOneResult<Facture>> UpdateFactureAsync(Facture Facture, int id)
        {
            var result = new GetOneResult<Facture>() { Success = false, Entity = null, Message = "something went wrong please verify the data and train again later !" };
            if (id != null && id > 0)
            {
                try
                {
                    var tsk = await _Table.FindAsync(id);
                    if (tsk != null)
                    {
                        tsk.FactureId = tsk.FactureId;
                        tsk.FactureRef = Facture.FactureRef;
                        tsk.Description = Facture.Description;
                        tsk.lastModified = Facture.lastModified;

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

        public  async Task<GetOneResult<Facture>> UpdateIsActivedAsync(bool IsActive, int id)
        {

            var result = new GetOneResult<Facture>();
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

        public async Task<GetOneResult<Facture>> UpdatestatusAsync(string status, int id)
        {
            var result = new GetOneResult<Facture>();
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
