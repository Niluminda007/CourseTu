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
using CourseTu.Helpers;
using CourseTu.CustomControls;
using CourseTu.inside;
using CourseTu.Messages;

namespace CourseTu.inside
{
    /// <summary>
    /// Interaction logic for CheckOut.xaml
    /// </summary>
    public partial class CheckOut : Window
    {
       
        public CheckOut()
        {
            InitializeComponent();

            this.lbcheck.ItemsSource = UserHelper.cart;


            double total = 0;
            

            
            for (int i = 0; i<UserHelper.cart.Count;i++)
            {
                double price = UserHelper.cart[i].price;
                int count = UserHelper.cart[i].quantity;
                double sum = price * count;
                total = total + sum;
                
            }
            sumtx.Text = Convert.ToString(total) + " € ";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderMethod om = new OrderMethod();
            om.Show();
            this.Close();
        }

        private void onCreditClick(object sender, RoutedEventArgs e)
        {
            creditCardDet details = new creditCardDet();
            details.Show();
            this.Close();
        }

        private void OnbtnClick2(object sender, RoutedEventArgs e)
        {
            if (OrderMethod.taken)
            {
                TakeAwayMsg msg = new TakeAwayMsg();
                msg.Show();
                this.Close();

            }
            else
            {
                OrderSuccesfullMsg delMsg = new OrderSuccesfullMsg();
                delMsg.Show();
                this.Close();
            }

        }
    }
}
