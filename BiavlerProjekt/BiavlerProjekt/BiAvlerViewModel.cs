using System;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;

namespace BiavlerProjekt
{
    public class BiAvlerViewModel : PropertyChangedBase
    {

        private string _bistade;
        private string _date;
        private string _count;
        private string _text;
        private ObservableCollection<BiAvler> _collection = new ObservableCollection<BiAvler>();
        private string _fileName;
        string filename = "";

        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
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

        public void Save()
        {
            if (filename != "" && Collection.Count > 0)
            {


                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<BiAvler>));
                TextWriter writer = new StreamWriter(FileName);
                // Serialize all the agents.
                serializer.Serialize(writer, Collection);
                writer.Close();
            }
        }

        public void SaveAs()
        {
            if (FileName != "")
            {
                filename = FileName;
                Save();

            }
            else
                MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public void Open()
        {
            filename = FileName;
            ObservableCollection<BiAvler> tempAgents = new ObservableCollection<BiAvler>();

            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<BiAvler>));
            try
            {
                TextReader reader = new StreamReader(filename);
                // Deserialize all the agents.
                tempAgents = (ObservableCollection<BiAvler>) serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // We have to insert the agents in the existing collection. If we just assign tempAgents to agents then the bindings to agents will brake!
            Collection.Clear();
            foreach (var agent in tempAgents)
                Collection.Add(agent);
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

    public class BiAvler : PropertyChangedBase
    {
        private string _text;
        private string _bistade;
        private string _date;
        private string _count;

        public string Bistade
        {
            get => _bistade;
            set
            {
                _bistade = value;
                NotifyOfPropertyChange();
            }
        }

        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                NotifyOfPropertyChange();
            }
        }

        public string Count
        {
            get => _count;
            set
            {
                _count = value;
                NotifyOfPropertyChange();
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
