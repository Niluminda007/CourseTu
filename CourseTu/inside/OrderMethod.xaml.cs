using CourseTu.inside.Delivery;
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
using System.Windows.Shapes;
using CourseTu.Messages;


namespace CourseTu.inside
{
    /// <summary>
    /// Interaction logic for OrderMethod.xaml
    /// </summary>
    public partial class OrderMethod : Window
    {
        public static bool taken = false;
        public OrderMethod()
        {
            InitializeComponent();
        }

       

        private void btnTakeAway(object sender, RoutedEventArgs e)
        {
            taken = true;
            CheckOut check = new CheckOut();
            check.Show();
            this.Close();
            
        }

        private void deliveryClick(object sender, RoutedEventArgs e)
        {
            taken = false;
            delivery del = new delivery();
            del.Show();
            this.Close();
        }
    }
}
