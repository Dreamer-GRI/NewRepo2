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
    /// Логика взаимодействия для OrderAddPage.xaml
    /// </summary>
    public partial class OrderAddPage : Page
    {
        public OrderAddPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order()
            {
                OrderNumber = txbOrderNumber.Text,
                OrderDate = DateTime.Parse(txbOrderDate.Text)
            };
            ConnectHelper.odbEnt.Order.Add(order);
            ConnectHelper.odbEnt.SaveChanges();
            MessageBox.Show("Данные успешно добавлены!");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new OrderPage());
        }
    }
}
