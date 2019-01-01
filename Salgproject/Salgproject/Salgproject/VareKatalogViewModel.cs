using System;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace Salgproject
{
    public class VareKatalogViewModel : PropertyChangedBase
    {
        private ObservableCollection<Vare> _vareKatalogCollection = new ObservableCollection<Vare>();

        private string _fileName;
        private string filename = "";

        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                NotifyOfPropertyChange();
            }
        }
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

        public void Save()
        {
            if (filename != "" && VareKatalogCollection.Count > 0 && filename != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Vare>));
                TextWriter writer = new StreamWriter(FileName);
                // Serialize the data

                serializer.Serialize(writer, VareKatalogCollection);

                writer.Close();

                FileName = null;
                MessageBox.Show($"Your data was saved to file: {filename}");

            }
            else
            {
                MessageBox.Show("invalid filename. Try again!");
            }
        }

        public void SaveAs()
        {
            if (FileName != "")
            {
                filename = FileName;
                Save();
                FileName = null;

            }
            else
                MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public void Open()
        {
            filename = FileName;
            ObservableCollection<Vare> products = new ObservableCollection<Vare>();

            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Vare>));
            try
            {
                TextReader reader = new StreamReader(filename);

                products = (ObservableCollection<Vare>)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            VareKatalogCollection.Clear();
            foreach (var product in products)
                VareKatalogCollection.Add(product);

            FileName = null;

        }

        public void Close()
        {
            MessageBoxResult result =
                MessageBox.Show("Do you want to exit the application?", "Warning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }

        public void New()
        {
            MessageBoxResult res = MessageBox.Show(
                "Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                VareKatalogCollection.Clear();
                filename = "";
            }
        }
    }
}
