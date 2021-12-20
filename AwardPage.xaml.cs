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
    public partial class AwardPage : Page
    {
        private List<Classes.Award> Items;
        private List<Classes.Employee> Employees;


        public AwardPage()
        {
            InitializeComponent();
            GetEmployeeBox();
            Get();
            ((MainWindow)System.Windows.Application.Current.MainWindow).exitIcon.Visibility = Visibility.Visible;
        }

        private void Get()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Awards"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Items = JsonConvert.DeserializeObject<List<Classes.Award>>(jsonString);
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
                int id = Items[dataGrid.SelectedIndex].IdAward;

                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Awards/" + id));
                WebReq.Method = "DELETE";
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                Get();
            }
            catch
            {

            }
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
            if (Validation() == true)
            {
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Awards"));
                WebReq.ContentType = "application/json; charset=utf-8";
                WebReq.Accept = "application/json; charset=utf-8";
                WebReq.Method = "POST";

                string employeeTxt = employeeBox.SelectedItem.ToString();
                int idEmployee = 0;
                foreach (var item in Employees)
                {
                    if (item.Surname == employeeTxt)
                    {
                        idEmployee = item.EmployeeId;
                    }
                }

                Award award = new Award
                {
                    EmployeeId = idEmployee,
                    Name = nameTxt.Text,
                    SalaryAdd = int.Parse(salaryAddTxt.Text)
                };
                Items.Add(award);



                using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(award);
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

        private void PUT(Award award)
        {
            try
            {
                int id = Items[dataGrid.SelectedIndex].IdAward;


                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Awards/" + id));
                WebReq.ContentType = "application/json; charset=utf-8";
                WebReq.Accept = "application/json; charset=utf-8";
                WebReq.Method = "PUT";

                using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(award);
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

        private bool Validation()
        {
            bool valid = true;
            if (nameTxt.Text == "" || salaryAddTxt.Text == "")
            {
                valid = false;
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.errorText.Text = "Необходимо заполнить все поля";
                errorWindow.Show();
            }
            else if (!nameTxt.Text.ToCharArray().All(x => Char.IsLetter(x)) || !salaryAddTxt.Text.ToCharArray().All(x => Char.IsDigit(x)))
            {
                valid = false;
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.errorText.Text = "Данные заполнены неверно";
                errorWindow.Show();
            }

            return valid;
        }

        private void idEmployeeCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idEmployeeCheck.IsChecked == false)
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

        private void salaryAddCheck_Click(object sender, RoutedEventArgs e)
        {
            if (salaryAddCheck.IsChecked == false)
                dataGrid.Columns[2].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[2].Visibility = Visibility.Visible;
        }
    }
}
