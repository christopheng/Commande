using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Commande.Views
{
    /// <summary>
    /// Logique d'interaction pour CommandeView.xaml
    /// </summary>
    public partial class CommandeView : Window, INotifyPropertyChanged
    {
        

        #region Commandes
        private ObservableCollection<Order> _orders; 
        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                if (_orders != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Orders"));
                }
                
            }
        }

        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedOrder"));
            }
        }
        #endregion

        #region Clients
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Clients"));
            }
        }
        #endregion

        #region Produits
        private ObservableCollection<Produit> _produits;
        public ObservableCollection<Produit> Produits
        {
            get { return _produits; }
            set
            {
                _produits = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Produits"));
            }
        }
        #endregion

        #region Get Lists

        private void GetAllOrders()
        {
            Orders = new ObservableCollection<Order>(DBCommandeContext.GetAllOrders());
        }

        private void GetAllClients()
        {
            Clients = new ObservableCollection<Client>(DBCommandeContext.GetAllClients());
        }

        private void GetAllProduits()
        {
            Produits = new ObservableCollection<Produit>(DBCommandeContext.GetAllProduits());
        }
        #endregion
        public CommandeView()
        {
            InitializeComponent();
            using (var myDB = new DBCommandeContext())
            {
                //myDB.Clients.Add(new Client { Nom = "Christophe", Telephone = "12345" });
                List<Produit> prods = new List<Produit>();
                prods.Add(new Produit { Name = "Buche", });
                myDB.Orders.Add(new Order { Boutique = 1, Client = new Client { Nom = "Ch", Telephone = "12344" }, Date = DateTime.Now, Recupere = 1 , Produits=prods});
                myDB.SaveChanges();
                Orders = new ObservableCollection<Order>(myDB.Orders.ToList());
            }
            

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
