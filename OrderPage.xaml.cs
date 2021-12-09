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
    public partial class OrderPage : Page
    {
        private List<Classes.Order> Items;
        private List<Classes.Car> Cars;
        private List<Classes.Employee> Employees;

        public OrderPage()
        {
            InitializeComponent();
            Get();
            GetCarBox();
            GetEmployeeBox();
        }

        private void Get()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Orders"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Items = JsonConvert.DeserializeObject<List<Classes.Order>>(jsonString);
            dataGrid.ItemsSource = Items;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Items[dataGrid.SelectedIndex].IdOrder;

                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Orders/" + id));
                WebReq.Method = "DELETE";
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                Get();
            }
            catch
            {

            }
        }

        private void GetCarBox()
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

            Cars = JsonConvert.DeserializeObject<List<Classes.Car>>(jsonString);

            foreach (var item in Cars)
            {
                carBox.Items.Add(item.Name);
            }
            carBox.SelectedIndex = 0;
        }

        private void GetEmployeeBox()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Employees"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Employees = JsonConvert.DeserializeObject<List<Classes.Employee>>(jsonString);

            foreach (var item in Employees)
            {
                employeeBox.Items.Add(item.Surname);
            }
            employeeBox.SelectedIndex = 0;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Orders"));
            WebReq.ContentType = "application/json; charset=utf-8";
            WebReq.Accept = "application/json; charset=utf-8";
            WebReq.Method = "POST";

            string carTxt = carBox.SelectedItem.ToString();
            int idCar = 0;
            foreach (var item in Cars)
            {
                if (item.Name == carTxt)
                {
                    idCar = item.CarId;
                }
            }

            string employeeTxt = employeeBox.SelectedItem.ToString();
            int idEmployee = 0;
            foreach (var item in Employees)
            {
                if (item.Surname == employeeTxt)
                {
                    idEmployee = item.EmployeeId;
                }
            }

            Order order = new Order
            {
                CarId = idCar,
                EmployeeId = idEmployee,
                Date = DateTime.Now
            };
            Items.Add(order);



            using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(order);
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

        private void idCarCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idCarCheck.IsChecked == false)
                dataGrid.Columns[3].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[3].Visibility = Visibility.Visible;
        }

        private void idEmployeeCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idEmployeeCheck.IsChecked == false)
                dataGrid.Columns[4].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[4].Visibility = Visibility.Visible;
        }

        private void dateCheck_Click(object sender, RoutedEventArgs e)
        {
            if (dateCheck.IsChecked == false)
                dataGrid.Columns[6].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[6].Visibility = Visibility.Visible;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.Columns[2].Visibility = Visibility.Hidden;
            dataGrid.Columns[5].Visibility = Visibility.Hidden;
        }
    }
}
