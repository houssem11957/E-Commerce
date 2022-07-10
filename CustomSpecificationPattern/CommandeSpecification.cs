using MyAxiaMarket1.DataAccess.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.CustomSpecificationPattern
{
    public static class CommandeSpecification
    {
        public async static Task<bool> Specification(IPanierRepository _repository, int panierId, IModeDePaiementRepository _mdprepositoty ,int mdpId)
        {
            try
            {
                var res = await _repository.GetPanierByIdAsync(panierId);
                var res1 = await _mdprepositoty.GetModeDePaiementByIdAsync(mdpId);
                return res.Success && res1.Success;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
