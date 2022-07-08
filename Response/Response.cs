using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.Response
{
    public class Response
    {
        public int NumberOfRecords { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class GetOneResult<TEntity> : Response where TEntity : class, new()
    {

        public TEntity Entity { get; set; }
    }
    public class GetManyResult<TEntity> : Response where TEntity : class, new()
    {
        public IEnumerable<TEntity> Entity { get; set; }
    }

    public class SignInModel<TEntity> :  Response where TEntity : class, new()
    {
        public TEntity Entity { get; set; }
        public string jwt { get; set; }
    }
}
