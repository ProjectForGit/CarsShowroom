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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new MainPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new PositionPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new CarPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new MarkPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new TypePage());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new AwardPage());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new VacationPage());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new TypeVacationPage());
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new Type_MaintenacePage());
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new MaintenancePage());
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new RepairPage());
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new AccessoryPage());
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new ColorPage());
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new ShippingPage());
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new OrderPage());
        }

        private void exitIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.MainFrameInstance.Navigate(new LoginPage());
        }
    }
}
