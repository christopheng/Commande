using System.ComponentModel.DataAnnotations.Schema;

namespace Commande
{
    public class Produit
    {
        public int ProduitId { get; set; }
        public string Name { get; set; }
        public decimal Prix { get; set; }
        public string Commentaire { get; set; }

        public int? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}