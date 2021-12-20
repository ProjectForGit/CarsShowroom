using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
    public partial class LoginPage : Page
    {
        private List<Classes.Employee> Items;

        public LoginPage()
        {
            InitializeComponent();
            Get();

            ((MainWindow)System.Windows.Application.Current.MainWindow).exitIcon.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validation() == true)
            {
                foreach (var item in Items)
                {
                    if (loginTxt.Text == item.Login && MD5(passwordTxt.Password) == item.Password)
                    {
                        CheckRole(item.Role);
                    }
                }
            }
            
        }

        private void Get()
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

            Items = JsonConvert.DeserializeObject<List<Classes.Employee>>(jsonString);
        }

        private string MD5(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }

        private bool Validation()
        {
            bool valid = true;
            if (loginTxt.Text == "" || passwordTxt.Password == "")
            {
                valid = false;
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.errorText.Text = "Данные заполнены неверно";
                errorWindow.Show();
            }
            
            
            return valid;
        }


        public void CheckRole(string role)
        {
            ((MainWindow)Application.Current.MainWindow).employeeButton.Margin = new Thickness(0, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).positionButton.Margin = new Thickness(130, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).carButton.Margin = new Thickness(260, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).markButton.Margin = new Thickness(390, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).typeButton.Margin = new Thickness(520, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).awardButton.Margin = new Thickness(650, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).vacationButton.Margin = new Thickness(780, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).typeVacationButton.Margin = new Thickness(910, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).typeMaintenanceButton.Margin = new Thickness(1040, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).maintenanceButton.Margin = new Thickness(1170, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).repairButton.Margin = new Thickness(1300, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).accessoryButton.Margin = new Thickness(1430, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).colorButton.Margin = new Thickness(1575, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).shippingButton.Margin = new Thickness(1705, 0, 0, 0);
            ((MainWindow)Application.Current.MainWindow).orderButton.Margin = new Thickness(1810, 0, 0, 0);



            ((MainWindow)Application.Current.MainWindow).orderButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).carButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).markButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).typeButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).employeeButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).positionButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).awardButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).vacationButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).typeMaintenanceButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).maintenanceButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).repairButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).colorButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).shippingButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).accessoryButton.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).typeVacationButton.Visibility = Visibility.Hidden;

            if (role == "Администратор")
            {
                ((MainWindow)Application.Current.MainWindow).orderButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).carButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).markButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).typeButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).employeeButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).positionButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).awardButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).vacationButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).typeMaintenanceButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).maintenanceButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).repairButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).colorButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).shippingButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).accessoryButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).typeVacationButton.Visibility = Visibility.Visible;

                MainWindow.MainFrameInstance.Navigate(new MainPage());
            }
            if (role == "Менеджер")
            {
                ((MainWindow)Application.Current.MainWindow).orderButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).carButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).markButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).typeButton.Visibility = Visibility.Visible;

                ((MainWindow)Application.Current.MainWindow).orderButton.Margin = new Thickness(0,0,0,0);
                ((MainWindow)Application.Current.MainWindow).carButton.Margin = new Thickness(130, 0, 0, 0);
                ((MainWindow)Application.Current.MainWindow).markButton.Margin = new Thickness(260, 0, 0, 0);
                ((MainWindow)Application.Current.MainWindow).typeButton.Margin = new Thickness(390, 0, 0, 0);

                MainWindow.MainFrameInstance.Navigate(new OrderPage());
            }
            else if (role == "Бухгалтер")
            {
                ((MainWindow)Application.Current.MainWindow).awardButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).vacationButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).typeVacationButton.Visibility = Visibility.Visible;

                ((MainWindow)Application.Current.MainWindow).awardButton.Margin = new Thickness(0, 0, 0, 0);
                ((MainWindow)Application.Current.MainWindow).vacationButton.Margin = new Thickness(130, 0, 0, 0);
                ((MainWindow)Application.Current.MainWindow).typeVacationButton.Margin = new Thickness(260, 0, 0, 0);

                MainWindow.MainFrameInstance.Navigate(new AwardPage());
            }
            else if (role == "Механик")
            {

                ((MainWindow)Application.Current.MainWindow).maintenanceButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).typeMaintenanceButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).repairButton.Visibility = Visibility.Visible;

                ((MainWindow)Application.Current.MainWindow).maintenanceButton.Margin = new Thickness(0, 0, 0, 0);
                ((MainWindow)Application.Current.MainWindow).typeMaintenanceButton.Margin = new Thickness(130, 0, 0, 0);
                ((MainWindow)Application.Current.MainWindow).repairButton.Margin = new Thickness(260, 0, 0, 0);

                MainWindow.MainFrameInstance.Navigate(new MaintenancePage());
            }
            else if (role == "Кладовщик")
            {

                ((MainWindow)Application.Current.MainWindow).accessoryButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).colorButton.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).shippingButton.Visibility = Visibility.Visible;

                ((MainWindow)Application.Current.MainWindow).accessoryButton.Margin = new Thickness(0, 0, 0, 0);
                ((MainWindow)Application.Current.MainWindow).colorButton.Margin = new Thickness(130, 0, 0, 0);
                ((MainWindow)Application.Current.MainWindow).shippingButton.Margin = new Thickness(260, 0, 0, 0);


                ((MainWindow)Application.Current.MainWindow).employeeButton.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).positionButton.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).carButton.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).markButton.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).typeButton.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).awardButton.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).vacationButton.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).typeMaintenanceButton.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).maintenanceButton.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).repairButton.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).orderButton.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).typeVacationButton.Visibility = Visibility.Hidden;

                MainWindow.MainFrameInstance.Navigate(new AccessoryPage());
            }
        }
    }
}
