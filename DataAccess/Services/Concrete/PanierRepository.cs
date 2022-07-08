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
    public class PanierRepository : Repository<Panier>, IPanierRepository
    {
        private readonly Context _context;
        private DbSet<Panier> _Table;
        public PanierRepository(DbContextOptions<Context> options) : base(options)
        {
            _context = new Context(options);
            _Table = _context.Set<Panier>();
        }

        public async Task<GetOneResult<Panier>> FindByTitle(string title)
        {
            var result = new GetOneResult<Panier>();
            if (!string.IsNullOrEmpty(title))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.NomPanier == title).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<Panier>> FindInDescriptionAsync(string description)
        {
            var result = new GetManyResult<Panier>();
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

        public async Task<GetOneResult<Panier>> GetPanierByIdAsync(int id)
        {
            var result = new GetOneResult<Panier>();
            try
            {
                var cres = await FindAll().Where(temp => temp.PanierId == id).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<Panier>> GetPaniersAsync(PagingParameters Parameters)
        {
            var result = new GetManyResult<Panier>();
            try
            {
                var cres = await FindAll()

               .OrderBy(temp => temp.PanierId)
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

        public async Task<GetManyResult<Panier>> GetsByStatusAsync(PagingParameters Parameters, string status)
        {
            var result = new GetManyResult<Panier>();
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

        public async Task<GetManyResult<Panier>> GetsByValidPanierAsync(PagingParameters Parameters, bool isValid)
        {
            var result = new GetManyResult<Panier>();

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

        public async Task<GetOneResult<Panier>> RemoveByIdAsync(int Panier)
        {
            var result = new GetOneResult<Panier>();
            if (Panier > 0)
            {
                try
                {
                    var res = await _Table.FindAsync(Panier);
                    if (res != null && (res.PanierId != 0))
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

        public async Task<GetOneResult<Panier>> UpdateIsActivedAsync(bool IsActive, int id)
        {
            var result = new GetOneResult<Panier>();
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

        public async Task<GetOneResult<Panier>> UpdatePanierAsync(Panier Panier, int id)
        {
            var result = new GetOneResult<Panier>() { Success = false, Entity = null, Message = "something went wrong please verify the data and train again later !" };
            if (id != null && id > 0)
            {
                try
                {
                    var tsk = await _Table.FindAsync(id);
                    if (tsk != null)
                    {
                        tsk.PanierId = tsk.PanierId;
                        tsk.NomPanier = Panier.NomPanier;
                        tsk.description = Panier.description;
                        tsk.lastModified = Panier.lastModified;

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

        public async Task<GetOneResult<Panier>> UpdatestatusAsync(string status, int id)
        {
            var result = new GetOneResult<Panier>();
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
