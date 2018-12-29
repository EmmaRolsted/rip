using Caliburn.Micro;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Xml.Serialization;

namespace BiavlerProjekt
{
    public class BiAvlerViewModel : PropertyChangedBase
    {
        private ICollectionView _dataGrCollectionView;
        private string _bistade;
        private string _date;
        private string _count;
        private string _text;
        private ObservableCollection<BiAvler> _collection = new ObservableCollection<BiAvler>();
        private string _fileName;
        string filename = "";
        private string _searchName;

        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                NotifyOfPropertyChange();
            }
        }

        public string SearchName
        {
            get => _searchName;
            set
            {
                _searchName = value;
                NotifyOfPropertyChange();
            }
        }

        public string Bistade1
        {
            get => _bistade;
            set
            {
                _bistade = value;
                NotifyOfPropertyChange();
            }
        }

        public string Date1
        {
            get => _date;
            set
            {
                _date = value;
                NotifyOfPropertyChange();
            }
        }

        public string Count1
        {
            get => _count;
            set
            {
                _count = value;
                NotifyOfPropertyChange();
            }
        }

        public string Text1
        {
            get => _text;
            set
            {
                _text = value;
                NotifyOfPropertyChange();
            }
        }


        public void Search()
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(Collection);

            if (SearchName == "")
                cv.Filter = null;
            
            else
            {
                cv.Filter = o =>
                {
                    BiAvler b = o as BiAvler;
                    return b.Bistade.ToUpper().StartsWith(SearchName.ToUpper());
                };

            }

        }
        
        public void Add()
        {
            if (Bistade1 != null && Date1 != null && Count1 != null && Text1 != null)
            {
                Collection.Add(new BiAvler() {Bistade = Bistade1, Date = Date1, Count = Count1, Text = Text1});
                Bistade1 = null;
                Date1 = null;
                Count1 = null;
                Text1 = null;
            }
        }

        public ObservableCollection<BiAvler> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                NotifyOfPropertyChange();
            }
        }

        private BiAvler _selectedCollection;
        public BiAvler SelectedCollection
        {
            get => _selectedCollection;
            set
            {
                _selectedCollection = value;
                NotifyOfPropertyChange();
            }
        }



        public void Save()
        {
            if (filename != "" && Collection.Count > 0 && filename != null)
            {


                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<BiAvler>));
                TextWriter writer = new StreamWriter(FileName);
                // Serialize all the agents.
                serializer.Serialize(writer, Collection);
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
            ObservableCollection<BiAvler> tempBi = new ObservableCollection<BiAvler>();

            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<BiAvler>));
            try
            {
                TextReader reader = new StreamReader(filename);
                // Deserialize all the agents.
                tempBi = (ObservableCollection<BiAvler>) serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // We have to insert the agents in the existing collection. If we just assign tempAgents to agents then the bindings to agents will brake!
            Collection.Clear();
            foreach (var bi in tempBi)
                Collection.Add(bi);

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
                Collection.Clear();
                filename = "";
            }
        }

    }
}
