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
using PR_VR3_GRISHIN.Pages;

namespace PR_VR3_GRISHIN.Pages
{
    /// <summary>
    /// Логика взаимодействия для CustomerChangePage.xaml
    /// </summary>
    public partial class CustomerChangePage : Page
    {
        private Customer cust = new Customer();
        public CustomerChangePage(Customer customer)
        {
            InitializeComponent();
            cust = customer;

            txbCustName.Text = cust.CustomerName;
            txbCustSur.Text = cust.CustomerSurname;
            txbCustNum.Text = cust.CustomerNumber;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            cust.CustomerName = txbCustName.Text;
            cust.CustomerSurname = txbCustSur.Text;
            cust.CustomerNumber = txbCustNum.Text;

            if (cust.idCustomer == 0)
            {
                ConnectHelper.odbEnt.Customer.Add(cust);
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
            FrameApp.FrameOBJ.Navigate(new CustomerPage());
        }
    }
}
