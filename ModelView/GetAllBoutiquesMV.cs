using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using MyAxiaMarket1.DataAccess.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyAxiaMarket.ModelView
{

    public class GetAllBoutiquesMV<TEntity> : IRequest<IEnumerable<TEntity>> where TEntity : IBoutiqueRepository
        {


            public GetAllBoutiquesMV(Expression<Func<TEntity, bool>> condition,
                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
            {
                Condition = condition;
                Includes = includes;

            }
            public Expression<Func<TEntity, bool>> Condition { get; }
            public Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Includes { get; }
        }
 }

