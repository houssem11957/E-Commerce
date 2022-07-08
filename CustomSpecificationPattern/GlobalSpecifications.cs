using Microsoft.AspNetCore.Identity;
using MyAxiaMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.CustomSpecificationPattern
{
    public static class GlobalSpecifications
    {
        public async static Task<bool> Specification(UserManager<Personne> _userManager,string  userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user != null)
                {

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
