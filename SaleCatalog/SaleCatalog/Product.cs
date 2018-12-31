using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace SaleCatalog
{
    public class Product : PropertyChangedBase
    {
        //Product information
        private string _productNumber;
        private string _productName;
        private string _productPrice;

        //Sales information:
        private int _amount;
        private string _selectedProduct;
        private string _unitPrice;
        private string _paymentMethod;

        //Sales information (properties)
        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                NotifyOfPropertyChange();
            }
        }

        public string SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                NotifyOfPropertyChange();
            }
        }

        public string UnitPrice
        {
            get => _unitPrice;
            set
            {
                _unitPrice = value; 
                NotifyOfPropertyChange();
            }
        }

        public string PaymentMethod
        {
            get => _paymentMethod;
            set
            {
                _paymentMethod = value;
                NotifyOfPropertyChange();
            }
        }


        //Product information (Properties)
        public string ProductNumber
        {
            get => _productNumber;
            set
            {
                _productNumber = value;
                NotifyOfPropertyChange();
            }
        }

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                NotifyOfPropertyChange();
            }
        }

        public string ProductPrice
        {
            get => _productPrice;
            set
            {
                _productPrice = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
