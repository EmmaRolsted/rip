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
        public int Amount { get; set; }
        public string SelectedProduct { get; set; }
        public string UnitPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
    }
}
