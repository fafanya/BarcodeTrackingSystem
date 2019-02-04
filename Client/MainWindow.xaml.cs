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
using Client.Service;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAddRoutePoint_Click(object sender, RoutedEventArgs e)
        {
            int routePointId = Controller.Instance.InsertRoutePoint(DataContext as RoutePoint);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new RoutePoint();
        }
    }
}
