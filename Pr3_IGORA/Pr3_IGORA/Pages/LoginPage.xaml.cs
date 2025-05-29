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
            TxbLogin.Focus();
           
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(TxbPassword.Password) || string.IsNullOrEmpty(TxbLogin.Text))
                {
                    MessageBox.Show("Пожалуйста заполните все поля!");
                    return;
                }
                    
                Trace.WriteLine($"My Login: {TxbLogin.Text}, My Password: {TxbPassword.Password}");

                foreach (var user in allUsers)
                {
                    Trace.WriteLine($"Login: {user.Login}, Password: {user.Password}");
                    if((user.Login == TxbLogin.Text) && (user.Password == TxbPassword.Password))
                    {
                        var efUser = ConnectBase.entObj.Employee.FirstOrDefault(x => x.Login == user.Login);
                        
                        if (efUser != null)
                        {
                            efUser.last_entry = DateTime.Now;
                            ConnectBase.entObj.SaveChanges();
                        }

                        switch (user.IDPost)
                        {
                            case 1:
                                
                                break;

                            case 2:
                                FrameApp.frmObj.Navigate(new AdminPage());

                                break;

                            case 3:
                                break;
                        }
                        return;
                    }    
                }

                Trace.WriteLine("Переходим в глубокую стадию");
                var userObj = ConnectBase.entObj.Employee.FirstOrDefault(x => x.Login == TxbLogin.Text && x.Password == TxbPassword.Password);

                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь отсутствует! Если у вас есть аккаунт внимательней просмотрите данные правильно ли вы ввели их, если у вас нет аккаунта пожалуйста зарегистрируйтесь!",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    return;
                }
                else
                {
                    userObj.last_entry = DateTime.Now;
                    ConnectBase.entObj.SaveChanges();

                    switch (userObj.IDPost)
                    {
                        case 1:

                            break;

                        case 2:
                            FrameApp.frmObj.Navigate(new AdminPage());
                            break;

                        case 3:
                            break;
                    }
                    return;
                }


            }
            catch
            {
                MessageBox.Show("Ошибка!Проверьте правильность ввода данных!");
                TxbPassword.Clear();
            }

        }

       
    }
}
