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
                // Получаем внешний PasswordBox через TemplatedParent
                PasswordBox outerPasswordBox = innerPasswordBox.TemplatedParent as PasswordBox;

                if (outerPasswordBox != null)
                {
                    //  ВНИМАНИЕ! Это ОЧЕНЬ ВАЖНО!
                    //  Отписываемся от события, чтобы избежать рекурсии
                    innerPasswordBox.PasswordChanged -= PART_PasswordBox_PasswordChanged;

                    outerPasswordBox.Password = innerPasswordBox.Password; // Обновляем внешний PasswordBox

                    // Подписываемся обратно
                    innerPasswordBox.PasswordChanged += PART_PasswordBox_PasswordChanged;
                }
            }
        }
    }
}
