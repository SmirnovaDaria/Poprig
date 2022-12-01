using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TestSpeed.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditAgentPage.xaml
    /// </summary>
    public partial class AddEditAgentPage : Page
    {
        public Agents Agent = new Agents();
        private bool isAdd = true;
        public AddEditAgentPage(Agents SelectAgent)
        {
            InitializeComponent();
            Agent = SelectAgent;
            TypeAgent.SelectedValuePath = "ID";
            TypeAgent.DisplayMemberPath = "Title";
            TypeAgent.ItemsSource = DB2_41_SmirnovaDEntities.GetContext().TypeAgent.ToList();
            TypeAgent.SelectedIndex = 0;
            if (SelectAgent != null)
            {
                ShowData();
                isAdd = false;
            }
            
        }

        public void ShowData()
        {
            Title.Text = Agent.Title;
            TypeAgent.SelectedIndex = (int)Agent.TypeAgentID-1;
            Priority.Text = Agent.Priority.ToString();
            Address.Text = Agent.UrAddress;
            INN.Text = Agent.INN;
            KPP.Text = Agent.KPP;
            Director.Text = Agent.Director;
            Phone.Text = Agent.Phone;
            Email.Text = Agent.Email;
        }

        private void SaveResult(object sender, RoutedEventArgs e)
        {
            Agent.Title = Title.Text;
            Agent.TypeAgentID = (int)TypeAgent.SelectedValue;
            Agent.Priority = int.Parse(Priority.Text);
            Agent.UrAddress = Address.Text;
            Agent.INN = INN.Text;
            Agent.KPP = KPP.Text;
            Agent.Director = Director.Text;
            Agent.Phone = Phone.Text;
            Agent.Email = Email.Text;
            if (isAdd)
            {
                DB2_41_SmirnovaDEntities.GetContext().Agents.Add(Agent);
            }
            DB2_41_SmirnovaDEntities.GetContext().SaveChanges();
            MainWindow.MainFrameWindow.Content = new Pages.ListAgent();
        }

        private void DeleteResult(object sender, RoutedEventArgs e)
        {
            if (isAdd==false)
            {
                DB2_41_SmirnovaDEntities.GetContext().Agents.Remove(Agent);
            }
            DB2_41_SmirnovaDEntities.GetContext().SaveChanges();
            MainWindow.MainFrameWindow.Content = new Pages.ListAgent();
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameWindow.Content = new Pages.ListAgent();
        }

        private void TextBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
