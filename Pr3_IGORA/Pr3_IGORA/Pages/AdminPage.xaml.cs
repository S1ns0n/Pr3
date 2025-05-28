using Pr3_IGORA.Classes;
using Pr3_IGORA.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Pr3_IGORA.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            
            Dg_Orders.ItemsSource = ConnectBase.entObj.Orders.ToList();
            Dg_Employes.ItemsSource = ConnectBase.entObj.Employee.ToList();
        }


        private void DgBtn_Employee_Info_Click(object sender, RoutedEventArgs e)
        {
            //FrameApp.frmObj.Navigate(new EmployeeInfoPage(sender as Button).DataContext Orders);

            var employee = (sender as Button)?.DataContext as Employee;

            if (employee == null)
            {
                MessageBox.Show("Не удалось получить данные заказа");
                return;
            }
            FrameApp.frmObj.Navigate(new EmployeeInfoPage(employee));
        }

        private void DgBtn_Order_Info_Click(object sender, RoutedEventArgs e)
        {
            var order = (sender as Button)?.DataContext as Orders;

            if (order == null)
            {
                MessageBox.Show("Не удалось получить данные заказа");
                return;
            }

            FrameApp.frmObj.Navigate(new PageInfoOrders(order));
        }

        private void addemploye_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
