using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Caliburn.Micro;

namespace Salgproject
{
    public class Vare : PropertyChangedBase
    {

        public int ItemNumber { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ItemCount { get; set; }
    }
}
