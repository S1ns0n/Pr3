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
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        public AddEmployeePage()
        {
            InitializeComponent();
            PositionComboBox.SelectedValuePath = "ID";
            PositionComboBox.DisplayMemberPath = "Post1";
            PositionComboBox.ItemsSource = ConnectBase.entObj.Post.ToList();
        }

        private void AddEmplBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = new Employee() { 
                    IDEmployee = Convert.ToInt32(id_employee_txb.Text),
                    Surname = LastNameTextBox.Text,
                    Name = FirstNameTextBox.Text,
                    Patronymic = MiddleNameTextBox.Text,
                    Login = LoginTextBox.Text,
                    Password = PasswordTextBox.Text,
                    IDPost = (int)PositionComboBox.SelectedValue,
                };
                ConnectBase.entObj.Employee.Add(employee);
                ConnectBase.entObj.SaveChanges();
                MessageBox.Show("Пользователь" + employee.Surname + employee.Name + employee.Patronymic + " успешно добавлен!", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                FrameApp.frmObj.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления пользователя", "Уведомление" + ex.Message.ToString(),
                   MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
