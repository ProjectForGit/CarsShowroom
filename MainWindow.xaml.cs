using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class MainWindow : Window
    {

        public static Frame MainFrameInstance;
        public MainWindow()
        {
            InitializeComponent();

            MainFrameInstance = MainFrame;
            MainFrame.Navigate(new LoginPage());
        }

        private void TextBlock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new MainPage());
        }

        private void Position_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new PositionPage());
        }

        private void Car_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new CarPage());
        }
        private void Mark_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new MarkPage());
        }

        private void Type_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new TypePage());
        }

        private void Award_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new AwardPage());
        }

        private void Vacation_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new VacationPage());
        }

        private void Type_Vacation_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new TypeVacationPage());
        }

        private void Type_Maintenance_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new Type_MaintenacePage());
        }

        private void Repair_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new RepairPage());
        }

        private void Accessory_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new AccessoryPage());
        }

        private void Color_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new ColorPage());
        }

        private void Shippping_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new ShippingPage());
        }

        private void Maintenance_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new MaintenancePage());
        }

        private void Order_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new OrderPage());
        }

        private void Employees_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new MainPage());
        }

        private void Maintenace_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new MaintenancePage());
        }

    }
}
