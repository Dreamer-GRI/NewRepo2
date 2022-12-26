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
    /// Логика взаимодействия для CustomerAddPage.xaml
    /// </summary>
    public partial class CustomerAddPage : Page
    {
        public CustomerAddPage()
        {
            InitializeComponent();
            cmbOrderNumber.SelectedValuePath = "idOrder";
            cmbOrderNumber.DisplayMemberPath = "OrderNumber";
            cmbOrderNumber.ItemsSource = ConnectHelper.odbEnt.Order.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new CustomerPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer()
            {
                CustomerName = txbCustName.Text,
                CustomerSurname = txbCustSur.Text,
                CustomerNumber = txbCustNum.Text,
                idOrder = int.Parse(cmbOrderNumber.SelectedValue.ToString())
            };
            ConnectHelper.odbEnt.Customer.Add(customer);
            ConnectHelper.odbEnt.SaveChanges();
            MessageBox.Show("Данные успешно добавлены!");
        }
    }
}
