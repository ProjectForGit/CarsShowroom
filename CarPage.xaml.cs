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

        private void PUT(Car car)
        {
            try
            {
                int id = Items[dataGrid.SelectedIndex].CarId;


                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Cars/" + id));
                WebReq.ContentType = "application/json; charset=utf-8";
                WebReq.Accept = "application/json; charset=utf-8";
                WebReq.Method = "PUT";

                using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(car);
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
        }

        private bool Validation()
        {
            bool valid = true;
            if (nameTxt.Text == "" || costTxt.Text == "" || gearboxTxt.Text == "" || maxSpeedTxt.Text == "" || weightTxt.Text == "")
            {
                valid = false;
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.errorText.Text = "Необходимо заполнить все поля";
                errorWindow.Show();
            }
            else if (!nameTxt.Text.ToCharArray().All(x => Char.IsLetter(x)) || !costTxt.Text.ToCharArray().All(x => Char.IsDigit(x)) || !gearboxTxt.Text.ToCharArray().All(x => Char.IsLetter(x)) || !maxSpeedTxt.Text.ToCharArray().All(x => Char.IsDigit(x)) || !weightTxt.Text.ToCharArray().All(x => Char.IsDigit(x)))
            {
                valid = false;
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.errorText.Text = "Данные заполнены неверно";
                errorWindow.Show();
            }

            return valid;
        }

        private void idMarkCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idMarkCheck.IsChecked == false)
                dataGrid.Columns[0].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[0].Visibility = Visibility.Visible;
        }

        private void nameCheck_Click(object sender, RoutedEventArgs e)
        {
            if (nameCheck.IsChecked == false)
                dataGrid.Columns[1].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[1].Visibility = Visibility.Visible;
        }

        private void idTypeCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idTypeCheck.IsChecked == false)
                dataGrid.Columns[2].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[2].Visibility = Visibility.Visible;
        }

        private void CostCheck_Click(object sender, RoutedEventArgs e)
        {
            if (costCheck.IsChecked == false)
                dataGrid.Columns[3].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[3].Visibility = Visibility.Visible;
        }

        private void yearCheck_Click(object sender, RoutedEventArgs e)
        {
            if (yearCheck.IsChecked == false)
                dataGrid.Columns[4].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[4].Visibility = Visibility.Visible;
        }

        private void idColorCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idColorCheck.IsChecked == false)
                dataGrid.Columns[5].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[5].Visibility = Visibility.Visible;
        }

        private void gearboxCheck_Click(object sender, RoutedEventArgs e)
        {
            if (gearboxCheck.IsChecked == false)
                dataGrid.Columns[6].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[6].Visibility = Visibility.Visible;
        }

        private void maxSpeedCheck_Click(object sender, RoutedEventArgs e)
        {
            if (maxSpeedCheck.IsChecked == false)
                dataGrid.Columns[7].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[7].Visibility = Visibility.Visible;
        }

        private void weightCheck_Click(object sender, RoutedEventArgs e)
        {
            if (weightCheck.IsChecked == false)
                dataGrid.Columns[8].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[8].Visibility = Visibility.Visible;
        }

        private void diagramButton_Click(object sender, RoutedEventArgs e)
        {
            DiagramWindow diagramWindow = new DiagramWindow();
            diagramWindow.Show();
        }
    }
}
