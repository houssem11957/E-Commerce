using Microsoft.EntityFrameworkCore;
using MyAxiaMarket.Models;
using MyAxiaMarket1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
        }

        public DbSet<Boutique> Boutiques { get; set; }
       
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<Commande> Commandes { get; set; }


    }


}

