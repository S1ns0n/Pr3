using Pr3_IGORA.Classes;
using Pr3_IGORA.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
using ZXing;

namespace Pr3_IGORA.Pages
{
    /// <summary>
    /// Логика взаимодействия для SellerPage.xaml
    /// </summary>
    public partial class SellerPage : Page
    {

        private object GetValue(object obj, string name)
        {
            return obj.GetType().GetProperty(name).GetValue(obj, null);
        }


        private BitmapImage GenerateBarcode(string barcodeContent)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.CODE_128; // Choose the format
            barcodeWriter.Options.Width = 250; //Set width of the barcode
            barcodeWriter.Options.Height = 80; //Set height of the barcode
            barcodeWriter.Options.Margin = 0; //Set margin.

            Bitmap barcodeBitmap = null;
            try
            {
                barcodeBitmap = barcodeWriter.Write(barcodeContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating barcode: {ex.Message}", "Error");
                return null;
            }
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                barcodeBitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }




            public SellerPage()
        {
            InitializeComponent();

            Cmb_Services.SelectedValuePath = "ID";
            Cmb_Services.DisplayMemberPath = "Name_Service";
            Cmb_Services.ItemsSource = ConnectBase.entObj.Service.ToList();

            Cmb_TimeRent.Items.Add("1 ч.");
            Cmb_TimeRent.Items.Add("2 ч.");
            Cmb_TimeRent.Items.Add("3 ч.");
            Cmb_TimeRent.Items.Add("4 ч.");
            Cmb_TimeRent.Items.Add("5 ч.");

        }

        private void Btn_CheckUser_Click(object sender, RoutedEventArgs e)
        {
            
            if(string.IsNullOrEmpty(Txb_Name.Text) || string.IsNullOrEmpty(Txb_Surname.Text) || string.IsNullOrEmpty(Txb_Patronumic.Text))
            {
                MessageBox.Show("Заполните поля!");
                return;
            }

            var ClientObj = ConnectBase.entObj.Client.FirstOrDefault(x=> x.Name == Txb_Name.Text && x.Surname == Txb_Surname.Text && x.Patronymic == Txb_Patronumic.Text);


            if (ClientObj != null)
            {
                MessageBox.Show($"Клиент существует. Номер телефона: {ClientObj.Phone_number}");
            }
            else
            {
                MessageBox.Show("Клиент не найден!");
            }


           
        }

        private void Cmb_Services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int service = Convert.ToInt32(Cmb_Services.SelectedValue.ToString());
            Trace.WriteLine($"Услуга: {service}");


            var serviceObj = ConnectBase.entObj.Service.Where(x=> x.ID == service).FirstOrDefault();

            

            Dg_Services.Items.Add(serviceObj);

        }

        private void Btn_DeleteService_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = Dg_Services.SelectedItems.Cast<object>().ToList();

            foreach (var selectedItem in selectedItems)
            {
                Dg_Services.Items.Remove(selectedItem);
            }
        }

        private void Btn_AddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {



                int cleint_id = 0;

                if (string.IsNullOrEmpty(Txb_Name.Text) || string.IsNullOrEmpty(Txb_Surname.Text) || string.IsNullOrEmpty(Txb_Patronumic.Text) || Dg_Services.Items.Count == 0 || Cmb_TimeRent.SelectedIndex == -1)
                {
                    MessageBox.Show("Заполните поля!");
                    return;
                }

                var ClientObj = ConnectBase.entObj.Client.FirstOrDefault(x => x.Name == Txb_Name.Text && x.Surname == Txb_Surname.Text && x.Patronymic == Txb_Patronumic.Text);



                if (ClientObj == null && string.IsNullOrEmpty(Txb_Phone.Text))
                {
                    MessageBox.Show("Вы создаёте заказ для нового клиента. Введите номер телефона");
                    return;
                }

                if (ClientObj == null)
                {
                    Client client = new Client()
                    {
                        Surname = Txb_Surname.Text,
                        Name = Txb_Name.Text,
                        Patronymic = Txb_Patronumic.Text,
                        Phone_number = Txb_Phone.Text,
                    };
                    ConnectBase.entObj.Client.Add(client);
                    ConnectBase.entObj.SaveChanges();

                    cleint_id = client.IDClient;
                }
                else
                {
                    cleint_id = ClientObj.IDClient;
                }

                Orders order = new Orders()
                {
                    DateTime_Order = DateTime.Now,
                    IDClient = cleint_id,
                    IDStatus = 1,
                    Time_Rent = (Cmb_TimeRent.SelectedIndex + 1) * 60

                };
                ConnectBase.entObj.Orders.Add(order);
                ConnectBase.entObj.SaveChanges();

                int order_id = order.IDOrder;

                var services = Dg_Services.Items;
                foreach (object service_item in services)
                {
                    string id_str = GetValue(service_item, "ID")?.ToString() ?? string.Empty;
                    int id = Convert.ToInt32(id_str);
                    Orders_Service order_service = new Orders_Service()
                    {
                        IDOrder = order_id,
                        IDService = id
                    };
                    ConnectBase.entObj.Orders_Service.Add(order_service);
                    ConnectBase.entObj.SaveChanges();

                }




                string barcode_text = order_id.ToString();

                Img_Barcode.Source = GenerateBarcode(barcode_text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании заказа: {ex}");
            }

        }


    }
}
