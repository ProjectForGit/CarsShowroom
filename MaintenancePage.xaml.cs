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

    public partial class MaintenancePage : Page
    {
        private List<Classes.Maintenance> Items;
        private List<Classes.TypeMaintenance> TypeMaintenances;
        private List<Classes.Repair> Repairs;
        private List<Classes.Employee> Employees;



        public MaintenancePage()
        {
            InitializeComponent();
            GetTypeMaintenanceBox();
            GetRepairBox();
            GetEmployeeBox();
            Get();
            ((MainWindow)System.Windows.Application.Current.MainWindow).exitIcon.Visibility = Visibility.Visible;
        }

        private void Get()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Maintenances"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Items = JsonConvert.DeserializeObject<List<Classes.Maintenance>>(jsonString);
            dataGrid.ItemsSource = Items;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Items[dataGrid.SelectedIndex].IdMaintenance;

                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Maintenances/" + id));
                WebReq.Method = "DELETE";
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                Get();
            }
            catch
            {

            }
        }

        private void GetTypeMaintenanceBox()
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

            TypeMaintenances = JsonConvert.DeserializeObject<List<Classes.TypeMaintenance>>(jsonString);

            foreach (var item in TypeMaintenances)
            {
                typeMaintenaceBox.Items.Add(item.Name);
            }
            typeMaintenaceBox.SelectedIndex = 0;
        }

        private void GetRepairBox()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Repairs"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Repairs = JsonConvert.DeserializeObject<List<Classes.Repair>>(jsonString);

            foreach (var item in Repairs)
            {
                repairBox.Items.Add(item.Problem);
            }
            repairBox.SelectedIndex = 0;
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
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Maintenances"));
            WebReq.ContentType = "application/json; charset=utf-8";
            WebReq.Accept = "application/json; charset=utf-8";
            WebReq.Method = "POST";

            string typeMaintenanceTxt = typeMaintenaceBox.SelectedItem.ToString();
            int idTypeMaintenance = 0;
            foreach (var item in TypeMaintenances)
            {
                if (item.Name == typeMaintenanceTxt)
                {
                    idTypeMaintenance = item.TypeMaintenanceId;
                }
            }

            int repairTxt = int.Parse(repairBox.SelectedItem.ToString());
            int idRepair = 0;
            foreach (var item in Repairs)
            {
                if (item.Cost == repairTxt)
                {
                    idRepair = item.RepairId;
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

            Maintenance maintenance = new Maintenance
            {
                TypeMaintenanceId = idTypeMaintenance,
                RepairId = idRepair,
                EmployeeId = idEmployee
            };
            Items.Add(maintenance);



            using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(maintenance);
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

        private void idTypeMaintenanceCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idTypeMaintenanceCheck.IsChecked == false)
                dataGrid.Columns[0].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[0].Visibility = Visibility.Visible;
        }

        private void idRepairCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idRepairCheck.IsChecked == false)
                dataGrid.Columns[1].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[1].Visibility = Visibility.Visible;
        }

        private void idEmployeeCheck_Click(object sender, RoutedEventArgs e)
        {
            if (idEmployeeCheck.IsChecked == false)
                dataGrid.Columns[2].Visibility = Visibility.Hidden;
            else
                dataGrid.Columns[2].Visibility = Visibility.Visible;
        }
    }
}
