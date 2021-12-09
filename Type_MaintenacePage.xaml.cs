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
    public partial class Type_MaintenacePage : Page
    {
        private List<Classes.TypeMaintenance> Items;

        public Type_MaintenacePage()
        {
            InitializeComponent();
            Get();
        }

        private void Get()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/TypeMaintenances"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Items = JsonConvert.DeserializeObject<List<Classes.TypeMaintenance>>(jsonString);
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
                int id = Items[dataGrid.SelectedIndex].TypeMaintenanceId;

                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/TypeMaintenances/" + id));
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
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/TypeMaintenances"));
            WebReq.ContentType = "application/json; charset=utf-8";
            WebReq.Accept = "application/json; charset=utf-8";
            WebReq.Method = "POST";

            TypeMaintenance typeMaintenance = new TypeMaintenance
            {
                Name = nameTxt.Text,
                Cost = int.Parse(costTxt.Text),
                Duration = int.Parse(durationTxt.Text)
            };
            Items.Add(typeMaintenance);



            using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(typeMaintenance);
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

        private void PUT(TypeMaintenance typeMaintenance)
        {
            try
            {
                int id = Items[dataGrid.SelectedIndex].TypeMaintenanceId;


                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/TypeMaintenances/" + id));
                WebReq.ContentType = "application/json; charset=utf-8";
                WebReq.Accept = "application/json; charset=utf-8";
                WebReq.Method = "PUT";

                using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(typeMaintenance);
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

        private void nameCheck_Click(object sender, RoutedEventArgs e)
        {
            if (nameCheck.IsChecked == false)
                dataGrid.Columns[2].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[2].Visibility = Visibility.Visible;
        }

        private void costCheck_Click(object sender, RoutedEventArgs e)
        {
            if (costCheck.IsChecked == false)
                dataGrid.Columns[3].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[3].Visibility = Visibility.Visible;
        }

        private void durationCheck_Click(object sender, RoutedEventArgs e)
        {
            if (durationCheck.IsChecked == false)
                dataGrid.Columns[4].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[4].Visibility = Visibility.Visible;
        }
    }
}
