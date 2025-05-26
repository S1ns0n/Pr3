using Pr3_IGORA.Classes;
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
using System.Diagnostics;

namespace Pr3_IGORA.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        List<UserCredentials> allUsers = UserRepository.GetAllUserCredentials();
        public LoginPage()
        {
            InitializeComponent();

            

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                Trace.WriteLine($"My Login: {TxbLogin.Text}, My Password: {TxbPassword.Password}");

                foreach (var user in allUsers)
                {
                    Trace.WriteLine($"Login: {user.Login}, Password: {user.Password}");
                    if((user.Login == TxbLogin.Text) && (user.Password == TxbPassword.Password))
                    {
                        MessageBox.Show("УРА");
                        return;
                    }


                }

                MessageBox.Show("фывфывф");


            }
            catch
            {
                MessageBox.Show("(((((");
            }

        }
    }
}
