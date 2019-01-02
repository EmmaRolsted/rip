using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;
using Caliburn.Micro;

namespace SaleCatalog
{
    class ProductViewModel : PropertyChangedBase
    {
        //private readonly ICollectionView _collectionView;
        private ObservableCollection<Product> _collection = new ObservableCollection<Product>();
        private ObservableCollection<Product> _saleCollection = new ObservableCollection<Product>();
        private string _fileName;
        private string filename = "";

        private List<string> _productBox = new List<string>();


        //Product information
        private string _productNumber;
        private string _productName;
        private string _productPrice;

        //Sales information
        private int _amount;
        private string _selectedProduct;
        private string _unitPrice;
        private string _paymentMethod;
        private string _cash;
        private string _totalPrice;

        public string TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                NotifyOfPropertyChange();
            }
        }
        public string Cash
        {
            get => _cash;
            set
            {
                _cash = value;
                NotifyOfPropertyChange();
            }
        }
        public string Payment
        {
            get => _paymentMethod;
            set
            {
                _paymentMethod = value;
                NotifyOfPropertyChange();
            }
        }
        public string Unit
        {
            get => _unitPrice;
            set
            {
                _unitPrice = value;
                NotifyOfPropertyChange();
            }
        }
        public string Selected
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                NotifyOfPropertyChange();
            }
        }
        public int Quantity
        {
            get => _amount;
            set
            {
                _amount = value;
                NotifyOfPropertyChange();
            }
        }

        public List<string> ProductBox
        {
            get => _productBox;
            set
            {
                _productBox = value;
                NotifyOfPropertyChange();
            }
        }
        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                NotifyOfPropertyChange();
            }
        }
        public string Number
        {
            get => _productNumber;
            set
            {
                _productNumber = value;
                NotifyOfPropertyChange();
            }
        }
        public string Name
        {
            get => _productName;
            set
            {
                _productName = value;
                NotifyOfPropertyChange();
            }
        }

        public string Price
        {
            get => _productPrice;
            set
            {
                _productPrice = value;
                NotifyOfPropertyChange();
            }
        }

        public ObservableCollection<Product> CollectionProducts
        {
            get => _collection;
            set
            {
                _collection = value;
                NotifyOfPropertyChange();
            }
        }

        public ObservableCollection<Product> SaleCollection
        {
            get => _saleCollection;
            set
            {
                _saleCollection = value;
                NotifyOfPropertyChange();
            }
        }

        //Serialize
        public void Save()
        {
            if (filename != "" && CollectionProducts.Count > 0 && filename != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Product>));
                TextWriter writer = new StreamWriter(FileName);
                // Serialize the data

                serializer.Serialize(writer, CollectionProducts);

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
            ObservableCollection<Product> products = new ObservableCollection<Product>();

            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Product>));
            try
            {
                TextReader reader = new StreamReader(filename);
                // Deserialize all the agents.
                products = (ObservableCollection<Product>)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            CollectionProducts.Clear();
            foreach (var product in products)
                CollectionProducts.Add(product);
           
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
                CollectionProducts.Clear();
                filename = "";
            }
        }

        #region SaveSalecatalog

        public void NewSale()
        {
            MessageBoxResult res = MessageBox.Show(
                "Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                SaleCollection.Clear(); ;
                filename = "";
            }
        }

        public void OpenSale()
        {
            filename = FileName;
            ObservableCollection<Product> products = new ObservableCollection<Product>();

            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Product>));
            try
            {
                TextReader reader = new StreamReader(filename);
                // Deserialize all the agents.
                products = (ObservableCollection<Product>)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            SaleCollection.Clear();
            foreach (var sale in products)
                SaleCollection.Add(sale);
            

            FileName = null;

        }

        public void SaveAsSale()
        {
            if (FileName != "")
            {
                filename = FileName;
                SaveSale();
                FileName = null;

            }
            else
                MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public void SaveSale()
        {
            if (filename != "" && SaleCollection.Count > 0 && filename != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Product>));
                TextWriter writer = new StreamWriter(FileName);
                // Serialize the data

                serializer.Serialize(writer, SaleCollection);
                //To serialize extra sale collection

                writer.Close();

                FileName = null;
                MessageBox.Show($"Your data was saved to file: {filename}");

            }
            else
            {
                MessageBox.Show("invalid filename. Try again!");
            }
        }
        #endregion

        public void Add()
        {
            if (Number != null && Price != null && Name != null)
            {
                CollectionProducts.Add(new Product() { ProductNumber = Number, ProductName = Name, ProductPrice = Price});
                Number = null;
                Name = null;
                Price = null;

                Update();
            }
        }

        public void CalculatePrice()
        {
            var testPrice = 0;

            foreach (var product in CollectionProducts)
            {
                if (product.ProductName == _selectedProduct)
                {
                    testPrice = int.Parse(product.ProductPrice);
                    TotalPrice = (testPrice * _amount).ToString();
                }

            }

        }

        public void Buy()
        {
            if (Payment != null && Selected != null && Payment != null)
            {
                var testPrice = 0;
                foreach (var product in CollectionProducts)
                {
                    if (product.ProductName == _selectedProduct)
                    {
                        testPrice = int.Parse(product.ProductPrice);
                        //_unitPrice = product.ProductPrice;
                    }
                }
                
                var price = testPrice *_amount;

                if (Payment == "MobilePay")
                {
                    SaleCollection.Add(new Product() { SelectedProduct = Selected, ProductName = Selected, Amount = Quantity, PaymentMethod = Payment, UnitPrice = testPrice.ToString() });

                    MessageBox.Show("Payment information:\n" +
                                    $"Amount: {_amount}.\n" +
                                    $"Product: {_selectedProduct}.\n" +
                                    $"Payment method: {_paymentMethod}.\n" +
                                    "\n\n" +
                                    "Return amount:   0       kr.");

                }

              
                if( Payment =="Cash")
                {
                    var cash = int.Parse(_cash);

                    if (cash < price)
                    {
                        MessageBox.Show($"Not enough money. The price is: {price} kr.\n Try again!");
                    }
                    else
                    {
                        MessageBox.Show("Payment information:\n" +
                                        $"Amount: {_amount}.\n" +
                                        $"Product: {_selectedProduct}.\n" +
                                        $"Payment method: {_paymentMethod}.\n" +
                                        "\n\n" +
                                        $"Price: {price} kr. \n" +
                                        $"Received amount: {Cash} kr. \n" +
                                        $"Return amount: {cash - price} kr.");
                        SaleCollection.Add(new Product() { SelectedProduct = Selected, ProductName = Selected, Amount = Quantity, PaymentMethod = Payment, UnitPrice = testPrice.ToString() });


                    }


                }

                Selected = null;
                Quantity = 0;
                Payment = null;
                TotalPrice = null;
            }
        }
        public void Update()
        {
            ProductBox.Clear();
            foreach (var product in CollectionProducts)
            {
                ProductBox.Add(product.ProductName);

            }
            
        }

        private Product _selectedCollectionProduct;
        public Product SeletedCollectionProduct
        {
            get => _selectedCollectionProduct;
            set
            {
                _selectedCollectionProduct = value;
                NotifyOfPropertyChange();
            }
        }


        public void Delete()
        {

            if (_selectedCollectionProduct != null)
            {
               
                    _collection.Remove(_selectedCollectionProduct);


            }
        }
    }
}
