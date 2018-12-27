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
                Collection.Add(new BiAvler() { Bistade = Bistade1, Date = Date1, Count = Count1, Text = Text1 });
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
                XmlSerializer serializer = new XmlSerializer(typeof(BiAvler));
                TextWriter writer = new StreamWriter(filename);
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
                
            }
            else
                MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        //public void Close()
        //{
        //    Close();
        //}

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
