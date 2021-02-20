using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commande
{
    public class Order
    {
        public int OrderId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        public ICollection<Produit> Produits { get; set; }

        public int Boutique { get; set; }

        public int Recupere { get; set; }
    }
}