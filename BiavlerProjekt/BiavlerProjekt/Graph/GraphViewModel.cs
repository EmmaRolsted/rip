using System;
using System.ComponentModel;
using System.Linq;
using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Definitions.Series;
using LiveCharts.Helpers;
using LiveCharts.Wpf;

namespace BiavlerProjekt.Graph
{
    public class GraphViewModel : PropertyChangedBase
    {
        private BiAvlerViewModel BiAvlerViewModel { get; set; }
        public GraphViewModel(BiAvlerViewModel biAvlerViewModel)
        {
            BiAvlerViewModel = biAvlerViewModel;

            BiAvlerViewModel.PropertyChanged += test_PropertyChanged;

       }

        private void test_PropertyChanged(object sender, PropertyChangedEventArgs e)
       {
            if (e.PropertyName == "Collection")
            {
                UpdateGraph();
            }


        }


        private string _labels;
        public string Labels
        {
            get => _labels;
            set
            {
                _labels = value;
                NotifyOfPropertyChange();
            }
        }
        private SeriesCollection _seriesCollection;
        public SeriesCollection SeriesCollection
        {
            get => _seriesCollection;
            set
            {
                _seriesCollection = value;
                NotifyOfPropertyChange();
            }
        }



        public Func<double, string> YFormatter { get; set; } = value => value.ToString("F");

        private void UpdateGraph()
        {

            Labels = nameof(BiAvlerViewModel.Bistade1);

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Hej",
                    Values = nameof(BiAvlerViewModel.Count1).AsChartValues()
                }
            };

        }




    }
}
