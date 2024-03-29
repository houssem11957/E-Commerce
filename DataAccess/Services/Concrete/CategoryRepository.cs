﻿using Microsoft.EntityFrameworkCore;
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
    public class CategoryRepository : Repository<Categorie>, ICategoryRepository
    {
        private readonly Context _context;
        private DbSet<Categorie> _Table;
        public CategoryRepository(DbContextOptions<Context> options) : base(options)
        {
            _context = new Context(options);
            _Table = _context.Set<Categorie>();
        }

        public async Task<GetOneResult<Categorie>> FindByTitle(string title)
        {
            var result = new GetOneResult<Categorie>();
            if (!string.IsNullOrEmpty(title))
            {
                try
                {
                    var res = await _Table.Where(temp => temp.NomCategorie == title).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<Categorie>> FindInDescriptionAsync(string description)
        {
            var result = new GetManyResult<Categorie>();
            if (!string.IsNullOrEmpty(description))
            {
                try
                {
                    var res = await  _Table.Where(temp => description.Any(a => temp.Description.Contains(a))).AsQueryable().ToListAsync();
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

        public async Task<GetOneResult<Categorie>> GetCategorieByIdAsync(int id)
        {
            var result = new GetOneResult<Categorie>();
            try
            {
                var cres = await FindAll().Where(temp => temp.IdCategorie == id).FirstOrDefaultAsync();
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

        public async Task<GetManyResult<Categorie>> GetCategoriesAsync(PagingParameters Parameters)
        {

            var result = new GetManyResult<Categorie>();
            try
            {
                var cres = await FindAll()

               .OrderBy(temp => temp.NomCategorie)
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

        public async Task<GetManyResult<Categorie>> GetsByNomCategorieAsync(PagingParameters Parameters, string nomCategorie)
        {
            var result = new GetManyResult<Categorie>();
            if (!string.IsNullOrEmpty(nomCategorie))
            {
                try
                {
                    var res = await _Table.Where(temp =>temp.NomCategorie == nomCategorie).ToListAsync();
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

        public async Task<GetManyResult<Categorie>> GetsByStatusAsync(PagingParameters Parameters, string status)
        {
            var result = new GetManyResult<Categorie>();
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

        public async Task<GetManyResult<Categorie>> GetsByvalideAsync(PagingParameters Parameters, bool valide)
        {
            var result = new GetManyResult<Categorie>();
            try
            {
                var cres = await FindAll()
                .Where(temp => temp.valide == valide)
               .OrderBy(temp => temp.NomCategorie)
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

        public async Task<GetOneResult<Categorie>> RemoveByIdAsync(int Categorie)
        {
            var result = new GetOneResult<Categorie>();
            if (Categorie > 0)
            {
                try
                {
                    var res = await _Table.FindAsync(Categorie);





                    if (res != null && (res.IdCategorie != 0))
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

        public async Task<GetOneResult<Categorie>> UpdateCategorieAsync(Categorie Categorie, int id)
        {


            var result = new GetOneResult<Categorie>() { Success = false, Entity = null, Message = "something went wrong please verify the data and train again later !" };
            if (Categorie != null)
            {
                try
                {
                    var tsk = await _Table.FindAsync(id);
                    if (tsk != null)
                    {
                        tsk.IdCategorie = tsk.IdCategorie;
                        tsk.Description = Categorie.Description;
                        tsk.NomCategorie = Categorie.NomCategorie;
                        tsk.lastModified = Categorie.lastModified;

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

        public async Task<GetOneResult<Categorie>> UpdateIsActivedAsync(bool IsActive, int id)
        {
            var result = new GetOneResult<Categorie>();
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

        public  async Task<GetOneResult<Categorie>> UpdatestatusAsync(string status, int id)
        {
            var result = new GetOneResult<Categorie>();
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
