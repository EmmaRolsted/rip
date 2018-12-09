using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgentAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Agents agents = new Agents();
        public MainWindow()
        {
            InitializeComponent();
            agents.Add(new Agent()
                {ID = "007", CodeName = "James Bond", Speciality = "UnderCover", Assignment = "Secret"});
            agents.Add(new Agent()
                { ID = "005", CodeName = "Nina", Speciality = "UnderCover", Assignment = "Secret" });

            AgentGrid.DataContext = agents;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedIndex > 0)
                ListBox.SelectedIndex = --ListBox.SelectedIndex;
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if(ListBox.SelectedIndex < ListBox.Items.Count -1)
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
            for (int i = ListBox.SelectedItems.Count-1; i >= 0; i--)
            {
                agents.Remove(ListBox.SelectedItems[i] as Agent);



            }







        }
    }
}
