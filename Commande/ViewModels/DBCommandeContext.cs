using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande
{
    public class DBCommandeContext:DbContext
    {
        public DBCommandeContext(): base("name=DBCommande") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        #region Tables
        public virtual DbSet<Produit> Produits { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Client> Clients { get; set; }
        #endregion


    }
}
