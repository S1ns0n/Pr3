using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Pr3_IGORA
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void PART_PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox innerPasswordBox = sender as PasswordBox;
            if (innerPasswordBox != null)
            {
                PasswordBox outerPasswordBox = innerPasswordBox.TemplatedParent as PasswordBox;

                if (outerPasswordBox != null)
                {
                    innerPasswordBox.PasswordChanged -= PART_PasswordBox_PasswordChanged;

                    outerPasswordBox.Password = innerPasswordBox.Password;
                    innerPasswordBox.PasswordChanged += PART_PasswordBox_PasswordChanged;
                }
            }
        }
    }
}
