using CarsShowroom.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace CarsShowroom
{
    public partial class ShippingPage : Page
    {
        private List<Classes.Shipping> Items;
        private List<Classes.Accessory> Accessories;

        public ShippingPage()
        {
            InitializeComponent();
            Get();
            GetAccessoryBox();
        }

        private void Get()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Shippings"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Items = JsonConvert.DeserializeObject<List<Classes.Shipping>>(jsonString);
            dataGrid.ItemsSource = Items;
            foreach (var item in Items)
            {
                item.PropertyChanged += delegate
                {
                    PUT(item);
                };
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Items[dataGrid.SelectedIndex].IdShipping;

                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Shippings/" + id));
                WebReq.Method = "DELETE";
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                Get();
            }
            catch
            {

            }
        }

        private void GetAccessoryBox()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Accessories"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Accessories = JsonConvert.DeserializeObject<List<Classes.Accessory>>(jsonString);

            foreach (var item in Accessories)
            {
                accessoryBox.Items.Add(item.Name);
            }
            accessoryBox.SelectedIndex = 0;

            orderDate.SelectedDate = DateTime.Now;
            shipDate.SelectedDate = DateTime.Now;
        }

        private void PUT(Shipping shipping)
        {
            try
            {
                int id = Items[dataGrid.SelectedIndex].IdShipping;


                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Shippings/" + id));
                WebReq.ContentType = "application/json; charset=utf-8";
                WebReq.Accept = "application/json; charset=utf-8";
                WebReq.Method = "PUT";

                using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(shipping);
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)WebReq.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch
            {

            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Validation() == true)
            {
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Shippings"));
                WebReq.ContentType = "application/json; charset=utf-8";
                WebReq.Accept = "application/json; charset=utf-8";
                WebReq.Method = "POST";

                string accessoryTxt = accessoryBox.SelectedItem.ToString();
                int idAccessory = 0;
                foreach (var item in Accessories)
                {
                    if (item.Name == accessoryTxt)
                    {
                        idAccessory = item.AccessoryId;
                    }
                }

                Shipping shipping = new Shipping
                {
                    Name = nameTxt.Text,
                    OrderDate = orderDate.SelectedDate.Value,
                    ShipDate = shipDate.SelectedDate.Value,
                    AccessoryId = idAccessory
                };
                Items.Add(shipping);



                using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(shipping);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)WebReq.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

                Get();
            }
        }
        private bool Validation()
        {
            bool valid = true;
            if (nameTxt.Text == "")
            {
                valid = false;
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.errorText.Text = "Необходимо заполнить все поля";
                errorWindow.Show();
            }
            else if (!nameTxt.Text.ToCharArray().All(x => Char.IsLetter(x)))
            {
                valid = false;
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.errorText.Text = "Данные заполнены неверно";
                errorWindow.Show();
            }

            return valid;
        }


        private void nameCheck_Click(object sender, RoutedEventArgs e)
        {
            if (nameCheck.IsChecked == false)
                dataGrid.Columns[0].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[0].Visibility = Visibility.Visible;
        }

        private void orderDateCheck_Click(object sender, RoutedEventArgs e)
        {
            if (orderDateCheck.IsChecked == false)
                dataGrid.Columns[1].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[1].Visibility = Visibility.Visible;
        }

        private void shipDateCheck_Click(object sender, RoutedEventArgs e)
        {
            if (shipDateCheck.IsChecked == false)
                dataGrid.Columns[2].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[2].Visibility = Visibility.Visible;
        }

        private void idAccessoryCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idAccessoryCheck.IsChecked == false)
                dataGrid.Columns[3].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[3].Visibility = Visibility.Visible;
        }
    }
}
