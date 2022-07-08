using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAxiaMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.Authentication.identityContext
{
    public class AuthContext: IdentityDbContext<Personne>
    {
        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {
        }
    }
}
