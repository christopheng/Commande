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

        #region Get All Elements
        public static List<Order> GetAllOrders()
        {
            var o = new List<Order>();
            using (var myDB=new DBCommandeContext())
            {
                var products = myDB.Produits.ToList();

                var clients = myDB.Clients.ToList();

                o = myDB.Orders.ToList();
            }
            return o;
        }

        public static List<Client> GetAllClients()
        {
            var c = new List<Client>();
            using(var myDB=new DBCommandeContext())
            {
                var products = myDB.Produits.ToList();
                var orders = myDB.Orders.ToList();
                c = myDB.Clients.ToList();
            }
            return c;
        }

        public static List<Produit> GetAllProduits()
        {
            var p = new List<Produit>();
            using (var myDB = new DBCommandeContext())
            {
                var clients = myDB.Clients.ToList();
                var orders = myDB.Orders.ToList();
                p = myDB.Produits.ToList();
            }
            return p;
        }
        #endregion

    }
}
