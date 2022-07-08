using MyAxiaMarket1.DataAccess.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.CustomSpecificationPattern
{
    public class FactureSpecification
    {
        public async static Task<bool> Specification(ICommandeRepository _repository, int commandId)
        {
            try
            {
                var res = await _repository.GetCommandeByIdAsync(commandId);
                return res.Success;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
