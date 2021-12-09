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
    public partial class CarPage : Page
    {
        private List<Classes.Car> Items;
        private List<Classes.Mark> Marks;
        private List<Classes.Type> Types;
        private List<Classes.Color> Colors;

        public CarPage()
        {
            InitializeComponent();
            Get();
            GetTypeBox();
            GetColorBox();
            GetMarkBox();
        }

        private void Get()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Cars"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Items = JsonConvert.DeserializeObject<List<Classes.Car>>(jsonString);
            dataGrid.ItemsSource = Items;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Items[dataGrid.SelectedIndex].CarId;

                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Cars/" + id));
                WebReq.Method = "DELETE";
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                Get();
            }
            catch
            {

            }
        }

        private void GetMarkBox()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Marks"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Marks = JsonConvert.DeserializeObject<List<Classes.Mark>>(jsonString);

            foreach (var item in Marks)
            {
                markBox.Items.Add(item.Name);
            }
            markBox.SelectedIndex = 0;
            yearDate.SelectedDate = DateTime.Now;
        }

        private void GetTypeBox()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Types"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Types = JsonConvert.DeserializeObject<List<Classes.Type>>(jsonString);

            foreach (var item in Types)
            {
                typeBox.Items.Add(item.Name);
            }
            typeBox.SelectedIndex = 0;
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Cars"));
            WebReq.ContentType = "application/json; charset=utf-8";
            WebReq.Accept = "application/json; charset=utf-8";
            WebReq.Method = "POST";

            string markTxt = markBox.SelectedItem.ToString();
            int idMark = 0;
            foreach (var item in Marks)
            {
                if (item.Name == markTxt)
                {
                    idMark = item.MarkId;
                }
            }

            string typeTxt = typeBox.SelectedItem.ToString();
            int idType = 0;
            foreach (var item in Types)
            {
                if (item.Name == typeTxt)
                {
                    idType = item.TypeId;
                }
            }

            string colorTxt = colorBox.SelectedItem.ToString();
            int idColor = 0;
            foreach (var item in Colors)
            {
                if (item.Name == colorTxt)
                {
                    idColor = item.ColorId;
                }
            }

            Car car = new Car
            {
                MarkId = idMark,
                Name = nameTxt.Text,
                TypeId = idType,
                Cost = int.Parse(costTxt.Text),
                Year = yearDate.SelectedDate.Value,
                ColorId = idColor,
                Gearbox = gearboxTxt.Text,
                MaxSpeed = int.Parse(maxSpeedTxt.Text),
                Weight = int.Parse(weightTxt.Text)
            };
            Items.Add(car);



            using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(car);
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

        private void idMarkCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idMarkCheck.IsChecked == false)
                dataGrid.Columns[3].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[3].Visibility = Visibility.Visible;
        }

        private void nameCheck_Click(object sender, RoutedEventArgs e)
        {
            if (nameCheck.IsChecked == false)
                dataGrid.Columns[4].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[4].Visibility = Visibility.Visible;
        }

        private void idTypeCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idTypeCheck.IsChecked == false)
                dataGrid.Columns[6].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[6].Visibility = Visibility.Visible;
        }

        private void CostCheck_Click(object sender, RoutedEventArgs e)
        {
            if (costCheck.IsChecked == false)
                dataGrid.Columns[7].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[7].Visibility = Visibility.Visible;
        }

        private void yearCheck_Click(object sender, RoutedEventArgs e)
        {
            if (yearCheck.IsChecked == false)
                dataGrid.Columns[8].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[8].Visibility = Visibility.Visible;
        }

        private void idColorCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idColorCheck.IsChecked == false)
                dataGrid.Columns[10].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[10].Visibility = Visibility.Visible;
        }

        private void gearboxCheck_Click(object sender, RoutedEventArgs e)
        {
            if (gearboxCheck.IsChecked == false)
                dataGrid.Columns[11].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[11].Visibility = Visibility.Visible;
        }

        private void maxSpeedCheck_Click(object sender, RoutedEventArgs e)
        {
            if (maxSpeedCheck.IsChecked == false)
                dataGrid.Columns[12].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[12].Visibility = Visibility.Visible;
        }

        private void weightCheck_Click(object sender, RoutedEventArgs e)
        {
            if (weightCheck.IsChecked == false)
                dataGrid.Columns[13].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[13].Visibility = Visibility.Visible;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.Columns[2].Visibility = Visibility.Hidden;
            dataGrid.Columns[5].Visibility = Visibility.Hidden;
            dataGrid.Columns[9].Visibility = Visibility.Hidden;
        }
    }
}
