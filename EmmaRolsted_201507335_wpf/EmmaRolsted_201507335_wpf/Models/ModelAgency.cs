using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaRolsted_201507335_wpf.Models
{
    public class ModelAgency
    {
        //Model information
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string HairColor { get; set; }
        public string CommentsModel { get; set; }

        //Client information
        public string ClientName { get; set; }
        public string StartDate { get; set; }
        public string Days { get; set; }
        public string Location { get; set; }
        public string NumberOfModels { get; set; }
        public string CommentsClient { get; set; }

        public string SelectedModel { get; set; }
        public string SelectedClient { get; set; }

    }
}
