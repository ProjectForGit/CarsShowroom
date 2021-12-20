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
    public partial class AccessoryPage : Page
    {
        private List<Classes.Accessory> Items;
        private List<Classes.Color> Colors;
        public AccessoryPage()
        {
            InitializeComponent();
            Get();
            GetColorBox();
            ((MainWindow)System.Windows.Application.Current.MainWindow).exitIcon.Visibility = Visibility.Visible;
        }

        private void Get()
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

            Items = JsonConvert.DeserializeObject<List<Classes.Accessory>>(jsonString);
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
                int id = Items[dataGrid.SelectedIndex].AccessoryId;

                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Accessories/" + id));
                WebReq.Method = "DELETE";
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                Get();
            }
            catch
            {

            }
        }

        private void GetColorBox()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Colors"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Colors = JsonConvert.DeserializeObject<List<Classes.Color>>(jsonString);

            foreach (var item in Colors)
            {
                colorBox.Items.Add(item.Name);
            }
            colorBox.SelectedIndex = 0;
        }

        private void PUT(Accessory accessory)
        {
            try
            {
                int id = Items[dataGrid.SelectedIndex].AccessoryId;


                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Accessories/" + id));
                WebReq.ContentType = "application/json; charset=utf-8";
                WebReq.Accept = "application/json; charset=utf-8";
                WebReq.Method = "PUT";

                using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(accessory);
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
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Accessories"));
                WebReq.ContentType = "application/json; charset=utf-8";
                WebReq.Accept = "application/json; charset=utf-8";
                WebReq.Method = "POST";

                string colorTxt = colorBox.SelectedItem.ToString();
                int idColor = 0;
                foreach (var item in Colors)
                {
                    if (item.Name == colorTxt)
                    {
                        idColor = item.ColorId;
                    }
                }

                Accessory accessory = new Accessory
                {
                    Name = nameTxt.Text,
                    Value = int.Parse(valueTxt.Text),
                    Cost = int.Parse(costTxt.Text),
                    ColorId = idColor
                };
                Items.Add(accessory);



                using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(accessory);
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
            if (nameTxt.Text == "" || valueTxt.Text == "" || costTxt.Text == "")
            {
                valid = false;
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.errorText.Text = "Необходимо заполнить все поля";
                errorWindow.Show();
            }
            else if (!nameTxt.Text.ToCharArray().All(x => Char.IsLetter(x)) || !valueTxt.Text.ToCharArray().All(x => Char.IsDigit(x)) || !costTxt.Text.ToCharArray().All(x => Char.IsDigit(x)))
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

        private void valueCheck_Click(object sender, RoutedEventArgs e)
        {
            if (valueCheck.IsChecked == false)
                dataGrid.Columns[1].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[1].Visibility = Visibility.Visible;
        }

        private void costCheck_Click(object sender, RoutedEventArgs e)
        {
            if (costCheck.IsChecked == false)
                dataGrid.Columns[2].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[2].Visibility = Visibility.Visible;
        }

        private void idColorCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idColorCheck.IsChecked == false)
                dataGrid.Columns[3].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[3].Visibility = Visibility.Visible;
        }
    }
}
