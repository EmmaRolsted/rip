using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.ComponentModel;

namespace BiavlerProjekt.Graph
{
    public class GraphViewModel : PropertyChangedBase
    {
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

        private BiAvlerViewModel BiAvlerViewModel { get; set; }
        public GraphViewModel(BiAvlerViewModel biAvlerViewModel)
        {
            BiAvlerViewModel = biAvlerViewModel;
            BiAvler.Instance.PropertyChanged += test_PropertyChanged;
        }

        private void test_PropertyChanged(object sender, PropertyChangedEventArgs e)
       {
            if (e.PropertyName == "Task")
            {
                    UpdateGraph();   
            }
        }

        private void UpdateGraph()
        {
            Labels = BiAvler.Instance.Task.Bistade;

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = string.Empty,
                    Values = new ChartValues<double> { BiAvler.Instance.Task.Count }
                }
            };

            YFormatter = value => value.ToString("N");
        }
    }
}
