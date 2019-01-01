using Caliburn.Micro;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Salgproject
{
    public class VareKatalogViewModel : PropertyChangedBase
    {
        private ObservableCollection<Vare> _vareKatalogCollection = new ObservableCollection<Vare>();
        public ObservableCollection<Vare> VareKatalogCollection
        {
            get => _vareKatalogCollection;
            set
            {
                _vareKatalogCollection = value;
                NotifyOfPropertyChange();
            }
        }

        private int _varenummer;

        public int Varenummer
        {
            get => _varenummer;
            set
            {
                _varenummer = value;
                NotifyOfPropertyChange();
            }
        }

        private string _navn;

        public string Navn
        {
            get => _navn;
            set
            {
                _navn = value;
                NotifyOfPropertyChange();
            }
        }

        private int _antal;

        public int Antal
        {
            get => _antal;
            set
            {
                _antal = value;
                NotifyOfPropertyChange();
            }
        }

        private int _pris;

        public int Pris
        {
            get => _pris;
            set
            {
                _pris = value;
                NotifyOfPropertyChange();
            }
        }

        public void Add()
        {

            VareKatalogCollection.Add(
                new Vare() { ItemNumber = Varenummer, Name = Navn, Price = Pris, ItemCount = Antal });
        }

        private List<string> _payment = new List<string>() { "Mobilepay", "Visa" };

        public List<string> Payment
        {
            get => _payment;
            set
            {
                _payment = value;
                NotifyOfPropertyChange();
            }
        }

        private string _paymentListText;
        public string PaymentListText
        {
            get => _paymentListText;
            set
            {
                _paymentListText = value;
                NotifyOfPropertyChange();
            }
        }

        private double _addition;
        public double Addition
        {
            get => _addition;
            set
            {
                _addition = value;
                NotifyOfPropertyChange();
            }
        }
        
        readonly List<Vare> _selectedVareKatalogCollection = new List<Vare>();
        public void Row_SelectionChanged(SelectionChangedEventArgs obj)
        {
            _selectedVareKatalogCollection.AddRange(obj.AddedItems.Cast<Vare>());
            obj.RemovedItems.Cast<Vare>().ToList().ForEach(w => _selectedVareKatalogCollection.Remove(w));

            if (_selectedVareKatalogCollection != null)
            {
                StringBuilder strBuilder = new StringBuilder();

                strBuilder.Append("Vare styk i pris i alt \n");

                double test = double.NaN;

                foreach (Vare selected in _selectedVareKatalogCollection)
                {
                    test = selected.Price * selected.ItemCount;
                    string str = $"{selected.Name}     {selected.Price}     {test}  \n";
                    strBuilder.Append(str);
                }

                PaymentListText = strBuilder.ToString();
                Addition = _selectedVareKatalogCollection.Select(d => d.Price * d.ItemCount).Sum();
            }
        }

        public void Delete()
        {
            if (_selectedVareKatalogCollection != null)
            {     
                foreach (Vare selected in _selectedVareKatalogCollection.ToList())
                {
                    VareKatalogCollection.Remove(selected);
                }
            }
        }
    }
}
