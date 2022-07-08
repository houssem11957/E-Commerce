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
    public class ContratRepository : Repository<Contrat>, IContratRepository
    {
        private readonly Context _context;
        private DbSet<Contrat> _Table;
        public ContratRepository(DbContextOptions<Context> options) : base(options)
        {
            _context = new Context(options);
            _Table = _context.Set<Contrat>();
        }

       

        public async Task<GetManyResult<Contrat>> FindInDescriptionAsync(string description)
        {
            var result = new GetManyResult<Contrat>();
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

        public async Task<GetManyResult<Contrat>> GetContratByContractNatureAsync(string nature)
        {
            var result = new GetManyResult<Contrat>();
            if (!string.IsNullOrEmpty(nature))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.ContractNature == nature).ToListAsync();
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

        public async Task<GetManyResult<Contrat>> GetContratByFournisseurAsync(string fournisseur)
        {
            var result = new GetManyResult<Contrat>();
            if (!string.IsNullOrEmpty(fournisseur))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.fournisseurId == fournisseur).ToListAsync();
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

        public async Task<GetOneResult<Contrat>> GetContratByIdAsync(int id)
        {
            var result = new GetOneResult<Contrat>();
            try
            {
                var cres = await FindAll().Where(temp => temp.ContractId == id).FirstOrDefaultAsync();
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

        public  async Task<GetManyResult<Contrat>> GetContratsAsync(PagingParameters Parameters)
        {
            var result = new GetManyResult<Contrat>();
            try
            {
                var cres = await FindAll()

               .OrderBy(temp => temp.ContractId)
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

        public async Task<GetManyResult<Contrat>> GetsByStatusAsync(PagingParameters Parameters, string status)
        {
            var result = new GetManyResult<Contrat>();
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

        public async Task<GetManyResult<Contrat>> GetsByvalideAsync(PagingParameters Parameters, bool valide)
        {
            var result = new GetManyResult<Contrat>();

            try
            {
                var res = await _Table.Where(temp => temp.valide == valide).ToListAsync();
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

        public async Task<GetOneResult<Contrat>> RemoveByIdAsync(int Contrat)
        {
            var result = new GetOneResult<Contrat>();
            if (Contrat > 0)
            {
                try
                {
                    var res = await _Table.FindAsync(Contrat);





                    if (res != null && (res.ContractId != 0))
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

        public async Task<GetOneResult<Contrat>> UpdateContratAsync(Contrat Contrat, int id)
        {
            var result = new GetOneResult<Contrat>() { Success = false, Entity = null, Message = "something went wrong please verify the data and train again later !" };
            if (Contrat != null && id > 0)
            {
                try
                {
                    var tsk = await _Table.FindAsync(id);
                    if (tsk != null)
                    {
                        tsk.ContractId = tsk.ContractId;
                        tsk.Description = Contrat.Description;
                        tsk.ContractNature = Contrat.ContractNature;
                        tsk.lastModified = Contrat.lastModified;

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

        public async Task<GetOneResult<Contrat>> UpdateIsActivedAsync(bool IsActive, int id)
        {
            var result = new GetOneResult<Contrat>();
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

        public async Task<GetOneResult<Contrat>> UpdatestatusAsync(string status, int id)
        {
            var result = new GetOneResult<Contrat>();
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
