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
    /// Логика взаимодействия для CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        public CustomerPage()
        {
            InitializeComponent();
            dgCustomer.ItemsSource = ConnectHelper.odbEnt.Customer.ToList();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = dgCustomer.SelectedItem as Customer;
            if (customer == null)
            {
                MessageBox.Show("Поле не выбрано");
            }
            else
            {
                FrameApp.FrameOBJ.Navigate(new CustomerChangePage(customer));
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = dgCustomer.SelectedItem as Customer;
            if (customer == null) MessageBox.Show("Запись не выбрана", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {

                if (MessageBox.Show("Хотите удалить выбранную запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ConnectHelper.odbEnt.Customer.Remove(customer);
                    ConnectHelper.odbEnt.SaveChanges();
                    dgCustomer.ItemsSource = ConnectHelper.odbEnt.Customer.ToList();
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new CustomerAddPage());
        }

        private void btnBckClick(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new MainPage());
        }
    }
}
