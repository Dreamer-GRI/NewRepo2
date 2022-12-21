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
using PR_VR3_GRISHIN.Classes;

namespace PR_VR3_GRISHIN.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new CustomerPage());
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new OrderPage());
        }
    }
}
