using System;
using System.ComponentModel;
using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Definitions.Series;
using LiveCharts.Helpers;
using LiveCharts.Wpf;

namespace BiavlerProjekt.Graph
{
    public class GraphViewModel : PropertyChangedBase
    {
        public GraphViewModel()
        {
            BiAvler.Instance.PropertyChanged += Bi_PropertyChanged;
        }

        private void Bi_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BiAvler.Instance.Bistade) && e.PropertyName == nameof(BiAvler.Instance.Count))
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
            Labels = nameof(BiAvler.Instance.Bistade);


            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Hej",
                    Values = nameof(BiAvler.Instance.Count).AsChartValues()
                }
            };

        }




    }
}
