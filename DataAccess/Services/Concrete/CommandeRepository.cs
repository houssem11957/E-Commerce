using MyAxiaMarket1.DataAccess.Abstract;
using MyAxiaMarket1.DataAccess.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAxiaMarket1.Models;
using MyAxiaMarket1.DataAccess.Concrete;
using MyAxiaMarket.Data;
using Microsoft.EntityFrameworkCore;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.Shared;

namespace MyAxiaMarket1.DataAccess.Services.Concrete
{
    public class CommandeRepository : Repository<Commande>, ICommandeRepository
    {
        private readonly Context _context;
        private DbSet<Commande> _Table;
        public CommandeRepository(DbContextOptions<Context> options) : base(options)
        {
            _context = new Context(options);
            _Table = _context.Set<Commande>();
        }

        public async Task<GetOneResult<Commande>> FindByTitle(string title)
        {
            var result = new GetOneResult<Commande>();
            if (!string.IsNullOrEmpty(title))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.commandRefrence == title).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<Commande>> FindInDescriptionAsync(string description)
        {

            var result = new GetManyResult<Commande>();
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

        public async Task<GetOneResult<Commande>> GetCommandeByIdAsync(int id)
        {
            var result = new GetOneResult<Commande>();
            try
            {
                var cres = await FindAll().Where(temp => temp.CommandId == id).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<Commande>> GetCommandesAsync(PagingParameters Parameters)
        {
            var result = new GetManyResult<Commande>();
            try
            {
                var cres = await FindAll()

               .OrderBy(temp => temp.commandRefrence)
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

        public Task<GetManyResult<Commande>> GetsByCategoryAsync(PagingParameters Parameters, int category)
        {
            throw new NotImplementedException();
        }

        public async Task<GetManyResult<Commande>> GetsByClientAsync(PagingParameters Parameters, string client)
        {
            var result = new GetManyResult<Commande>();
            if (!string.IsNullOrEmpty(client))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.clientId == client).ToListAsync();
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

        

        public async Task<GetOneResult<Commande>> GetsByRefCommandeAsync(PagingParameters Parameters, string Reference)
        {
            var result = new GetOneResult<Commande>();
            if (!string.IsNullOrEmpty(Reference))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.commandRefrence == Reference).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<Commande>> GetsByStatusAsync(PagingParameters Parameters, string status)
        {
            var result = new GetManyResult<Commande>();
            if (!string.IsNullOrEmpty(status))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.status == status).ToListAsync();
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

        public async Task<GetManyResult<Commande>> GetsByvalideAsync(PagingParameters Parameters, bool valide)
        {
            var result = new GetManyResult<Commande>();

            try
            {
                var res = await _Table.Where(temp => temp.valide == valide).ToListAsync();
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
            return result;
        }
           
        

        public async Task<GetOneResult<Commande>> RemoveByIdAsync(int Commande)
        {
            var result = new GetOneResult<Commande>();
            if (Commande > 0)
            {
                try
                {
                    var res = await _Table.FindAsync(Commande);





                    

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

        public async Task<GetOneResult<Commande>> UpdateCommandeAsync(Commande Commande, int id)
        {
            var result = new GetOneResult<Commande>() { Success = false, Entity = null, Message = "something went wrong please verify the data and train again later !" };
            if (Commande != null && id > 0)
            {
                try
                {
                    var tsk = await _Table.FindAsync(id);
                    if (tsk != null)
                    {
                        tsk.CommandId = tsk.CommandId;
                        tsk.Description = Commande.Description;
                        tsk.commandRefrence = Commande.commandRefrence;
                        tsk.lastModified = Commande.lastModified;

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

        public async Task<GetOneResult<Commande>> UpdateIsActivedAsync(bool IsActive, int id)
        {
            var result = new GetOneResult<Commande>();
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

        public async Task<GetOneResult<Commande>> UpdatestatusAsync(Commande Commande, int id)
        {
            var result = new GetOneResult<Commande>();
            if (id > 0 && ((string.IsNullOrEmpty(Commande.status))))
            {
                try
                {
                    var res = await _Table.FindAsync(id);
                    if (res != null)
                    {
                        res.status = Commande.status;
                        res.CommandId = res.CommandId;
                        res.lastModified = Commande.lastModified;
                        res.modifiedBy = Commande.modifiedBy;
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
