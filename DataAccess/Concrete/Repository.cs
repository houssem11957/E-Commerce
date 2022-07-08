using Microsoft.EntityFrameworkCore;
using MyAxiaMarket.Data;
using MyAxiaMarket1.DataAccess.Abstract;
using MyAxiaMarket1.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyAxiaMarket1.DataAccess.Concrete
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()

    {
        public Context _context;
        private DbSet<TEntity> _Table;
        public Repository(DbContextOptions<Context> options)
        {
            _context = new Context(options);
            _Table = _context.Set<TEntity>();
        }


        public async Task<GetOneResult<TEntity>> DeleteByIdAsync(int id)
        {
            var result = new GetOneResult<TEntity>();
            if (id > 0)
            {
                try
                {
                    var sResult = await _Table.FindAsync(id);
                    if (sResult != null)
                    {
                        _Table.Remove(sResult);
                        var sRes = await _context.SaveChangesAsync();
                        if (sRes > 0)
                        {
                            result.Entity = sResult;
                            result.Message = "data removed Successfully !";
                            result.Success = true;
                        }
                    }
                }
                catch (Exception exp)
                {
                    result.Entity = null;
                    result.Success = false;
                    result.Message = "error occured !" + exp.Message + exp.Source;
                   
                }



            }
            return result;
        }

        public async Task<GetOneResult<TEntity>> DeleteOneAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var sResult = await _Table.Where(filter).FirstOrDefaultAsync();
                if (sResult != null)
                {
                    var res = _Table.Remove(sResult);
                    await _context.SaveChangesAsync();
                    result.Entity = sResult;
                    result.Message = "data removed Successfully";
                    result.Success = true;

                }
            }
            catch (Exception exp)
            {
                result.Entity = null;
                result.Message = "error was occured possible reason : " + exp.Message;
                result.Success = false;
            }
            return result;
        }



        public async Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var res = await _Table.Where(filter).ToListAsync();
                if (res.Count() > 0)
                {
                    result.Entity = res;
                    result.Success = true;
                    result.Message = "search completed !";
                }

            }
            catch (Exception exp)
            {
                result.Entity = null;
                result.Success = false;
                result.Message = exp.Message + exp.Source;
               
            }

            return result;
        }


        // get All the Entity from the Db 
        public async Task<GetManyResult<TEntity>> GetAllAsync()
        {
            var Tab = new GetManyResult<TEntity>();
            try
            {

                if (await _Table.AnyAsync())
                {
                    Tab.Entity = await _Table.AsQueryable().ToListAsync();

                    if (Tab.Entity != null)
                    {
                        Tab.Success = true;

                    }
                }

            }
            catch (Exception exp)
            {
                Tab.Success = false;
                Tab.Message = exp.Message + exp.Source;
                
            }

            return Tab;
        }



        public async Task<GetOneResult<TEntity>> GetByIdAsync(int id)
        {
            var result = new GetOneResult<TEntity>();
            if (id > 0)
            {
                try
                {
                    result.Entity = await _Table.FindAsync(id);
                    if (result.Entity != null)
                    {
                        result.Success = true;
                        result.Message = "Search completed ! ";
                    }

                }
                catch (Exception exp)
                {
                    result.Entity = null;
                    result.Success = false;
                    result.Message = exp.Message + exp.Source;
                    
                }


            }
            return result;
        }



        public async Task<GetManyResult<TEntity>> InsertManyAsync(ICollection<TEntity> Entity)
        {
            var result = new GetManyResult<TEntity>();
            if (Entity != null)
            {
                try
                {
                    await _Table.AddRangeAsync(Entity);
                    var saveRes = await _context.SaveChangesAsync();
                    if (saveRes > 0)
                    {
                        result.Entity = Entity;
                        result.Message = "data added Successfully";
                        result.Success = true;
                    }


                }
                catch (Exception exp)
                {
                    result.Entity = Entity;
                    result.Message = "error was occured possible reasons : " + exp.Message;
                    result.Success = false;
                    
                }
            }
            return result;

        }



        public async Task<GetOneResult<TEntity>> InsertOneAsync(TEntity Entity)
        {
            var result = new GetOneResult<TEntity>();
            if (Entity != null)
            {
                try
                {
                    await _Table.AddAsync(Entity);
                    var saveRes = await _context.SaveChangesAsync();
                    if (saveRes > 0)
                    {
                        result.Entity = Entity;
                        result.Success = true;
                        result.Message = "data was added Successfully";
                    }


                }
                catch (Exception exp)
                {
                    result.Success = false;
                    result.Message = exp.Source;
                }
            }

            return result;
        }



        public async Task<GetOneResult<TEntity>> ReplaceOneAsync(TEntity Entity, int id)
        {
            var result = new GetOneResult<TEntity>();

            if (Entity != null)
            {
                try
                {
                    var user = await _Table.FindAsync(id);

                    _Table.Update(Entity);

                    var saveRes = await _context.SaveChangesAsync();
                    if (saveRes > 0)
                    {
                        result.Entity = Entity;
                        result.Success = true;
                        result.Message = "data was Modified Successfully";
                    }


                }
                catch (Exception exp)
                {
                    result.Entity = null;
                    result.Success = false;
                    result.Message = exp.Source;
                }
            }

            return result;
        }

        public IQueryable<TEntity> FindAll()
        {
            return this._context.Set<TEntity>();
        }


    }


}
