using CarsShowroom.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
    public partial class PositionPage : Page
    {
        private List<Position> Items;
        public PositionPage()
        {
            InitializeComponent();
            Get();
        }

        private void Get()
        {
            Debug.WriteLine("get");
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Positions"));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Items = JsonConvert.DeserializeObject<List<Position>>(jsonString);
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
                int id = Items[dataGrid.SelectedIndex].PositionId;

                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Positions/" + id));
                WebReq.Method = "DELETE";
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                Get();
            }
            catch
            {

            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Positions"));
            WebReq.ContentType = "application/json; charset=utf-8";
            WebReq.Accept = "application/json; charset=utf-8";
            WebReq.Method = "POST";

            Position position = new Position
            {
                Name = nameTxt.Text,
                Salary = int.Parse(salaryTxt.Text)
            };
            Items.Add(position);



            using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(position);
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

        private void PUT(Position position)
        {
            try
            {
                int id = Items[dataGrid.SelectedIndex].PositionId;


                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Positions/" + id));
                WebReq.ContentType = "application/json; charset=utf-8";
                WebReq.Accept = "application/json; charset=utf-8";
                WebReq.Method = "PUT";

                using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(position);
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

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new FilterPage());
        }

        private void nameCheck_Click(object sender, RoutedEventArgs e)
        {
            if (nameCheck.IsChecked == false)
                dataGrid.Columns[2].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[2].Visibility = Visibility.Visible;
        }

        private void salaryCheck_Click(object sender, RoutedEventArgs e)
        {
            if (salaryCheck.IsChecked == false)
                dataGrid.Columns[3].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[3].Visibility = Visibility.Visible;
        }
    }
}

