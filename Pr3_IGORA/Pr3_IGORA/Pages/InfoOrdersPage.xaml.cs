
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Pr3_IGORA.Classes;
using Pr3_IGORA.Database;

namespace Pr3_IGORA.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageInfoOrders.xaml
    /// </summary>
    public partial class PageInfoOrders : Page
    {

        public PageInfoOrders(Orders order)
        {
            InitializeComponent();

            string surname = order.Client.Surname;
            string name = order.Client.Name;
            string patronymic = order.Client.Patronymic;


            txbFIO.Text = $"{surname} {name} {patronymic}";
            txbDlitel.Text = order.Time_Rent.ToString();
            txbShrihcode.Text = order.IDOrder.ToString();

            Dg_Srvice.ItemsSource = ConnectBase.entObj.Orders_Service.Where(x => x.IDOrder == order.IDOrder).ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
