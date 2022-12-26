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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            dgOrder.ItemsSource = ConnectHelper.odbEnt.Order.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new OrderAddPage());
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Order order = dgOrder.SelectedItem as Order;
            if (order == null) MessageBox.Show("Запись не выбрана", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {

                if (MessageBox.Show("Хотите удалить выбранную запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ConnectHelper.odbEnt.Order.Remove(order);
                    ConnectHelper.odbEnt.SaveChanges();
                    dgOrder.ItemsSource = ConnectHelper.odbEnt.Order.ToList();
                }
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            Order order = dgOrder.SelectedItem as Order;
            if (order == null)
            {
                MessageBox.Show("Поле не выбрано");
            }
            else
            {
                FrameApp.FrameOBJ.Navigate(new OrderChangePage(order));
            }
        }

        private void btnBckClick(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new MainPage());
        }
    }
}
