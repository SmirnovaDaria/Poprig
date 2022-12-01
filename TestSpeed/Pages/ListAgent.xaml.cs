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

namespace TestSpeed.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListAgent.xaml
    /// </summary>
    public partial class ListAgent : Page
    {
        private int NumberPage = 1;
        private int ValuePage;
        private List<Run> NumPage = new List<Run>();
        public ListAgent()
        {
            InitializeComponent();
            NumPage.Add(NumPage1);
            NumPage.Add(NumPage2);
            NumPage.Add(NumPage3);
            NumPage.Add(NumPage4);
            NumPage[0].TextDecorations = TextDecorations.Underline;
            ValuePage = DB2_41_SmirnovaDEntities.GetContext().Agents.Count()%10 == 0? DB2_41_SmirnovaDEntities.GetContext().Agents.Count()/10: DB2_41_SmirnovaDEntities.GetContext().Agents.Count()/10+1;
            var data = DB2_41_SmirnovaDEntities.GetContext().Agents.ToList();
            foreach (var agent in data)
            {
                agent.AllLogoPath = "/Resources/Images/" + agent.LogoPath;
                int? value = DB2_41_SmirnovaDEntities.GetContext().Sale.Where(x=>x.AgentsID==agent.ID).Sum(x=>x.ValueProduct);
                agent.ValueSale = (int)(value==null? 0:value);
                agent.Discount = GetDiscount(agent.ValueSale);
            }
            AgentLisatView.ItemsSource = data;
        }

        public float GetDiscount(int value)
        {
            float discount = 0;
            if (value <= 10000)
            {
                discount = 0;
            }
            else if (value <= 50000)
            {
                discount = 5;
            }
            else if (value <= 150000)
            {
                discount = 10;
            }
            else if (value <= 500000)
            {
                discount = 20;
            }
            else
            {
                discount = 25;
            }
            return discount;
        }

        private void NavigationListAgentNum(object sender, MouseButtonEventArgs e)
        {

        }
        private void NavigationListAgentArow(object sender, MouseButtonEventArgs e)
        {
            string text = (sender as Run).Text;
            if (text == "<")
            {
                if (NumberPage>1)
                {
                    NumberPage--;
                    if (int.Parse(NumPage[0].Text) > 1)
                    {
                        foreach (var item in NumPage)
                        {
                            item.Text = (int.Parse(item.Text) - 1).ToString();
                        }
                    }
                }
            }
            else
            {
                if (NumberPage < ValuePage)
                {
                    NumberPage++;
                    if (int.Parse(NumPage[3].Text) < ValuePage)
                    {
                        foreach (var item in NumPage)
                        {
                            item.Text = (int.Parse(item.Text) + 1).ToString();
                        }
                    }
                }
            }
            foreach (var item in NumPage)
            {
                if (item.Text== NumberPage.ToString())
                {
                    item.TextDecorations = TextDecorations.Underline;
                }
                else
                {
                    item.TextDecorations = null;
                }
            }
        }

        private void OpenAgent(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameWindow.Content= new Pages.AddEditAgentPage((sender as DockPanel).DataContext as Agents);
        }

        private void AddAgent(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameWindow.Content = new Pages.AddEditAgentPage(null);
        }
    }
}
