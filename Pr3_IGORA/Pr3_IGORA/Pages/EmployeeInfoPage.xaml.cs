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
using Pr3_IGORA.Classes;
using Pr3_IGORA.Database;

namespace Pr3_IGORA.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeeInfoPage.xaml
    /// </summary>
    public partial class EmployeeInfoPage : Page
    {
        public EmployeeInfoPage(Employee employee)
        {
            InitializeComponent();


            LastNameTextBox.Text = employee.Surname;
            FirstNameTextBox.Text = employee.Name;
            MiddleNameTextBox.Text = employee.Patronymic;
            PositionTextBox.Text = employee.Post.Post1;
            LastLoginTextBox.Text = (employee.last_entry).ToString();
            LoginTextBox.Text = employee.Login;
            PasswordTextBox.Text = employee.Password;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
