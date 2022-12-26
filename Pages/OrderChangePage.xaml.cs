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
    /// Логика взаимодействия для OrderChangePage.xaml
    /// </summary>
    public partial class OrderChangePage : Page
    {
        private Order ord = new Order();
        public OrderChangePage(Order order)
        {
            InitializeComponent();
            ord = order;

            txbOrderNumber.Text = ord.OrderNumber;
            txbOrderDate.Text = ord.OrderDate.ToString();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            ord.OrderNumber = txbOrderNumber.Text;
            ord.OrderDate = DateTime.Parse(txbOrderDate.Text);

            if (ord.idOrder == 0)
            {
                ConnectHelper.odbEnt.Order.Add(ord);
            }

            try
            {
                ConnectHelper.odbEnt.SaveChanges();
                MessageBox.Show("Данные успешно изменены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new OrderPage());
        }
    }
}
