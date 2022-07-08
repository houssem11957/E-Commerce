using MyAxiaMarket1.DataAccess.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.CustomSpecificationPattern
{
    public static class CommandeSpecification
    {
        public async static Task<bool> Specification(IPanierRepository _repository, int panierId)
        {
            try
            {
                var res = await _repository.GetPanierByIdAsync(panierId);
                return res.Success;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
