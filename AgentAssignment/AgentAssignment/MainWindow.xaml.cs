using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace AgentAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filename = "";
        private readonly Agents agents = new Agents();

        public MainWindow()
        {
            InitializeComponent();
            agents.Add(new Agent()
                {ID = "007", CodeName = "James Bond", Speciality = "UnderCover", Assignment = "Secret"});
            agents.Add(new Agent()
                {ID = "005", CodeName = "Nina", Speciality = "UnderCover", Assignment = "Secret"});

            AgentGrid.DataContext = agents;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedIndex > 0)
                ListBox.SelectedIndex = --ListBox.SelectedIndex;
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedIndex < ListBox.Items.Count - 1)
                ListBox.SelectedIndex = ++ListBox.SelectedIndex;
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            agents.Add(new Agent());
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
            ListBox.ItemsSource = agents;
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            for (int i = ListBox.SelectedItems.Count - 1; i >= 0; i--)
            {
                agents.Remove(ListBox.SelectedItems[i] as Agent);
            }
        }

        private void New_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show(
                "Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                agents.Clear();
                filename = "";
            }
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result =
                MessageBox.Show("Do you want to exit the application?", "Warning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void SaveAs_OnClick(object sender, RoutedEventArgs e)
        {
            if (tbxFileName.Text != "")
            {
                filename = tbxFileName.Text;
                Save_OnClick(null, null);
            }
            else
                MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(Agents));
            TextWriter writer = new StreamWriter(filename);
            // Serialize all the agents.
            serializer.Serialize(writer, agents);
            writer.Close();
        }

        private void Open_OnClick(object sender, RoutedEventArgs e)
        {
            filename = tbxFileName.Text;
            Agents tempAgents = new Agents();

            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(Agents));
            try
            {
                TextReader reader = new StreamReader(filename);
                // Deserialize all the agents.
                tempAgents = (Agents) serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // We have to insert the agents in the existing collection. If we just assign tempAgents to agents then the bindings to agents will brake!
            agents.Clear();
            foreach (var agent in tempAgents)
                agents.Add(agent);
        }
    }
}