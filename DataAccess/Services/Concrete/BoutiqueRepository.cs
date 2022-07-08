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
    public class BoutiqueRepository : Repository<Boutique>, IBoutiqueRepository
    {
        private readonly Context _context;
        private DbSet<Boutique> _Table;
        public BoutiqueRepository(DbContextOptions<Context> options) : base(options)
        {
            _context = new Context(options);
            _Table = _context.Set<Boutique>();
        }

        public async Task<GetOneResult<Boutique>> FindByTitle(string title)
        {

            var result = new GetOneResult<Boutique>();
            if (!string.IsNullOrEmpty(title))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.NomBoutique == title).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<Boutique>> FindInDescriptionAsync(string description)
        {
            var result = new GetManyResult<Boutique>();
            if (!string.IsNullOrEmpty(description))
            {
                try
                {
                    var res = _Table.Where(temp => description.Any(a => temp.Description.Contains(a))).AsQueryable().ToList();
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

        public async Task<GetManyResult<Boutique>> GetLatestBoutiques(int numberOfRecord)
        {
            var result = new GetManyResult<Boutique>() { Message = "number of record must be lower than 50 per query !" };
            if (numberOfRecord > 0 && numberOfRecord < 50)
                try
                {


                    var res = await _Table.Where(x => x.IdBoutique > 0).OrderByDescending(x => x.IdBoutique).ToListAsync();
                    if (res.Count > 0 && res.Count > numberOfRecord)
                    {
                        var list = res.Take(numberOfRecord);
                        result.Entity = list;
                        result.Message = "search completed";
                        result.Success = true;
                    }
                    else
                    {
                        var list = res;
                        result.Entity = list;
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

        public async Task<GetOneResult<Boutique>> UpdateIsActivedAsync(bool IsActive, int id)
        {
            var result = new GetOneResult<Boutique>();
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

        public async Task<GetOneResult<Boutique>> UpdatestatusAsync(string status, int id)
        {
            var result = new GetOneResult<Boutique>();
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

        public async Task<GetOneResult<Boutique>> UpdateBoutiqueAsync(Boutique boutique, int id)
        {
            var result = new GetOneResult<Boutique>() { Success = false, Entity = null, Message = "something went wrong please verify the data and train again later !" };
            if (boutique != null)
            {
                try
                {
                    var tsk = await _Table.FindAsync(id);
                    if (tsk != null)
                    {
                        tsk.IdBoutique = tsk.IdBoutique;
                        tsk.Description = boutique.Description;
                        tsk.NomBoutique = boutique.NomBoutique;
                        tsk.NatureBoutique = boutique.NatureBoutique;
                        tsk.lastModified = boutique.lastModified;

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

        public async Task<GetOneResult<Boutique>> RemoveByIdAsync(int boutiqueId)
        {
            var result = new GetOneResult<Boutique>();
            if (boutiqueId > 0)
            {
                try
                {
                    var res = await _Table.FindAsync(boutiqueId);





                    if (res != null && (res.IdBoutique != 0))
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


        public async Task<GetManyResult<Boutique>> GetsByStatusAsync(PagingParameters Parameters, string status)
        {
            var result = new GetManyResult<Boutique>();
            try
            {
                var cres = await FindAll()
                .Where(temp => temp.status == status)
               .OrderBy(temp => temp.NomBoutique)
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

        public async Task<GetManyResult<Boutique>> GetsByNomBoutiqueAsync(PagingParameters Parameters, string NomBoutique)
        {
            var result = new GetManyResult<Boutique>();
            try
            {
                var cres = await FindAll()
                .Where(temp => temp.NomBoutique == NomBoutique)
               .OrderBy(temp => temp.NomBoutique)
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

        public async Task<GetManyResult<Boutique>> GetsByNatureBoutiqueAsync(PagingParameters Parameters, string natureBoutique)
        {
            var result = new GetManyResult<Boutique>();
            try
            {
                var cres = await FindAll()
                .Where(temp => temp.NomBoutique == natureBoutique)
               .OrderBy(temp => temp.NomBoutique)
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
        public async Task<GetManyResult<Boutique>> GetsByvalideAsync(PagingParameters Parameters, bool valide)
        {
            var result = new GetManyResult<Boutique>();
            try
            {
                var cres = await FindAll()
                .Where(temp => temp.valide == valide)
               .OrderBy(temp => temp.NomBoutique)
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
        public async Task<GetManyResult<Boutique>> GetsByManagerIdAsync(PagingParameters Parameters, string ManagerId)
        {
            var result = new GetManyResult<Boutique>();
            try
            {
                var cres = await FindAll()
                .Where(temp => temp.ManagerId == ManagerId)
               .OrderBy(temp => temp.NomBoutique)
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

        public async Task<GetManyResult<Boutique>> GetBoutiquesAsync(PagingParameters Parameters)
        {
            var result = new GetManyResult<Boutique>();
            try
            {
                var cres = await FindAll()

               .OrderBy(temp => temp.NomBoutique)
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

        public async Task<GetOneResult<Boutique>> GetBoutiqueByIdAsync(int id)
        {
            var result = new GetOneResult<Boutique>();
            try
            {
                var cres = await FindAll().Where(temp => temp.IdBoutique == id).FirstOrDefaultAsync();
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
       

     

       
    }
}
