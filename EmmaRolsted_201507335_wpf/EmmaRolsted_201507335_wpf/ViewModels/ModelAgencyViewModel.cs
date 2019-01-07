using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Caliburn.Micro;
using EmmaRolsted_201507335_wpf.Models;

namespace EmmaRolsted_201507335_wpf.ViewModels
{
    public class ModelAgencyViewModel : PropertyChangedBase
    {
        private ObservableCollection<ModelAgency> _modelCollection = new ObservableCollection<ModelAgency>();
        private ObservableCollection<ModelAgency> _clientCollection = new ObservableCollection<ModelAgency>();
        private ObservableCollection<ModelAgency> _assignmentsCollection = new ObservableCollection<ModelAgency>();

        private string _fileName;
        private string filename = "";

        //Model information
        private string _name;
        private string _phoneNumber;
        private string _address;
        private string _height;
        private string _weight;
        private string _hairColor;
        private string _commentsModel;
        
        //Client information
        private string _clientName;
        private string _startDate;
        private string _numberOfDays;
        private string _location;
        private string _numberOfModels;
        private string _commentsClient;

        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                NotifyOfPropertyChange();
            }
        }

        public ObservableCollection<ModelAgency> ModelCollection
        {
            get => _modelCollection;
            set
            {
                _modelCollection = value;
                NotifyOfPropertyChange();
            }
        }

        public ObservableCollection<ModelAgency> ClientCollection
        {
            get => _clientCollection;
            set
            {
                _clientCollection = value;
                NotifyOfPropertyChange();
            }
        }

        public ObservableCollection<ModelAgency> AssignmentCollection
        {
            get => _assignmentsCollection;
            set
            {
                _assignmentsCollection = value;
                NotifyOfPropertyChange();
            }
        }

        #region ModelInformation
        
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyOfPropertyChange();
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                NotifyOfPropertyChange();
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                NotifyOfPropertyChange();
            }
        }

        public string Height
        {
            get => _height;
            set
            {
                _height = value;
                NotifyOfPropertyChange();
            }
        }

        public string Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                NotifyOfPropertyChange();
            }
        }

        public string HairColor
        {
            get => _hairColor;
            set
            {
                _hairColor = value;
                NotifyOfPropertyChange();
            }
        }

        public string CommentsModel
        {
            get => _commentsModel;
            set
            {
                _commentsModel = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

        #region ClientProperties

        public string ClientName
        {
            get => _clientName;
            set
            {
                _clientName = value;
                NotifyOfPropertyChange();
            }
        }

        public string StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                NotifyOfPropertyChange();
            }
        }

        public string Days
        {
            get => _numberOfDays;
            set
            {
                _numberOfDays = value;
                NotifyOfPropertyChange();
            }
        }

        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                NotifyOfPropertyChange();
            }
        }

        public string NumberOfModels
        {
            get => _numberOfModels;
            set
            {
                _numberOfModels = value;
                NotifyOfPropertyChange();
            }
        }

        public string CommentsClient
        {
            get => _commentsClient;
            set
            {
                _commentsClient = value;
                NotifyOfPropertyChange();
            }
        }

        #endregion

        #region SaveModelData
        public void Save()
        {
            if (filename != "" && ModelCollection.Count > 0 && filename != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ModelAgency>));
                TextWriter writer = new StreamWriter(FileName);
                // Serialize the data

                serializer.Serialize(writer, ModelCollection);

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
            ObservableCollection<ModelAgency> products = new ObservableCollection<ModelAgency>();

            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ModelAgency>));
            try
            {
                TextReader reader = new StreamReader(filename);
                // Deserialize all the agents.
                products = (ObservableCollection<ModelAgency>)serializer.Deserialize(reader);
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            ModelCollection.Clear();
            foreach (var product in products)
                ModelCollection.Add(product);

            FileName = null;
            UpdateModels();

        }


        public void NewModel()
        {
            MessageBoxResult res = MessageBox.Show(
                "Any unsaved data in Models will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                ModelCollection.Clear();
                filename = "";
            }
        }


        #endregion

        #region File
        public void New()
        {
            MessageBoxResult res = MessageBox.Show(
                "Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                ModelCollection.Clear();
                ClientCollection.Clear();
                filename = "";
            }
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


        #endregion

        #region SaveClientData
        public void SaveClient()
        {
            if (filename != "" && ClientCollection.Count > 0 && filename != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ModelAgency>));
                TextWriter writer = new StreamWriter(FileName);
                
                // Serialize the clients

                serializer.Serialize(writer, ClientCollection);

                writer.Close();

                FileName = null;
                MessageBox.Show($"Your data was saved to file: {filename}");

            }
            else
            {
                MessageBox.Show("invalid filename. Try again!");
            }
        }

        public void SaveAsClient()
        {
            if (FileName != "")
            {
                filename = FileName;
                SaveClient();
                FileName = null;

            }
            else
                MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public void OpenClient()
        {
            filename = FileName;
            ObservableCollection<ModelAgency> clients = new ObservableCollection<ModelAgency>();

            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ModelAgency>));
            try
            {
                TextReader reader = new StreamReader(filename);
                // Deserialize all the Clients
                clients = (ObservableCollection<ModelAgency>)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            ClientCollection.Clear();
            foreach (var client in clients)
                ClientCollection.Add(client);

            FileName = null;
            UpdateClients();

        }
        
        public void NewClient()
        {
            MessageBoxResult res = MessageBox.Show(
                "Any unsaved data in Clients will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                ClientCollection.Clear();
                filename = "";
            }
        }

        #endregion

        #region SaveAssignmentData
        public void SaveAssignment()
        {
            if (filename != "" && ClientCollection.Count > 0 && filename != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ModelAgency>));
                TextWriter writer = new StreamWriter(FileName);

                // Serialize the clients

                serializer.Serialize(writer, AssignmentCollection);

                writer.Close();

                FileName = null;
                MessageBox.Show($"Your data was saved to file: {filename}");

            }
            else
            {
                MessageBox.Show("invalid filename. Try again!");
            }
        }
        public void SaveAsAssignment()
        {
            if (FileName != "")
            {
                filename = FileName;
                SaveAssignment();
                FileName = null;

            }
            else
                MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public void OpenAssignment()
        {
            filename = FileName;
            ObservableCollection<ModelAgency> assignments = new ObservableCollection<ModelAgency>();

            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ModelAgency>));
            try
            {
                TextReader reader = new StreamReader(filename);
                // Deserialize all the Clients
                assignments = (ObservableCollection<ModelAgency>)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            AssignmentCollection.Clear();
            foreach (var assignment in assignments)
                AssignmentCollection.Add(assignment);

            FileName = null;
        }

        public void NewAssignment()
        {
            MessageBoxResult res = MessageBox.Show(
                "Any unsaved data in Assignments will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                ClientCollection.Clear();
                filename = "";
            }
        }

        #endregion
        public void AddModel()
        {
            if (Name != null && PhoneNumber != null && Address != null && Height != null && Weight != null && HairColor != null && CommentsModel != null )
            {
                ModelCollection.Add(new ModelAgency{Name = Name, PhoneNumber = PhoneNumber, Address = Address, Height = Height, Weight = Weight, HairColor = HairColor, CommentsModel = CommentsModel});

                Name = null;
                PhoneNumber = null;
                Address = null;
                Height = null;
                Weight = null;
                HairColor = null;
                CommentsModel = null;

                UpdateModels();
            }
        }
        public void Match()
        {
            if (SelectedModel != null && SelectedClient != null)
            {
                AssignmentCollection.Add(new ModelAgency {SelectedClient = SelectedClient, SelectedModel = SelectedModel});

                SelectedClient = null;
                SelectedModel = null;
            }

        }
        public void AddClient()
        {
            if (ClientName != null && StartDate != null && Days != null && Location != null && NumberOfModels != null && CommentsClient != null) 
            {
                ClientCollection.Add(new ModelAgency{ClientName = ClientName, StartDate = StartDate, Days = Days, Location = Location, NumberOfModels = NumberOfModels, CommentsClient = CommentsClient});

                ClientName = null;
                StartDate = null;
                Days = null;
                Location = null;
                NumberOfModels = null;
                CommentsClient = null;
                
                UpdateClients();
            }
        }

        private ObservableCollection<string> _models = new ObservableCollection<string>();

        public ObservableCollection<string> Models
        {
            get => _models;
            set
            {
                _models = value;
                NotifyOfPropertyChange();
            }
        }

        private ObservableCollection<string> _clients = new ObservableCollection<string>();

        public ObservableCollection<string> Clients
        {
            get => _clients;
            set
            {
                _clients = value;
                NotifyOfPropertyChange();
            }
        }

        public void UpdateModels()
        {
            Models.Clear();
            foreach (var model in ModelCollection)
            {
                Models.Add(model.Name);
                NotifyOfPropertyChange((() => SelectedModel));

            }

        }

        public void UpdateClients()
        {
            Clients.Clear();
            foreach (var client in ClientCollection)
            {
                Clients.Add(client.ClientName);
                NotifyOfPropertyChange((() => SelectedClient));
            }

        }

        private string _selectedModel;

        public string SelectedModel
        {
            get => _selectedModel;
            set
            {
                _selectedModel = value;
                NotifyOfPropertyChange();
            }
        }

        private string _selectedClient;

        public string SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
