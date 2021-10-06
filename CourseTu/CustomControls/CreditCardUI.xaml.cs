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
using CourseTu.CustomControls;
using CourseTu.Messages;
using CourseTu.inside;

namespace CourseTu.CustomControls
{
    /// <summary>
    /// Interaction logic for CreditCardUI.xaml
    /// </summary>
    public partial class CreditCardUI : Window
    {
        public CreditCardUI()
        {
            InitializeComponent();
            CardNo.Text = creditCardDet.credit[0].CardNumber;
            NameOnC.Text = creditCardDet.credit[0].Name;
            date.Text = creditCardDet.credit[0].ExDate;
            seCode.Text = (creditCardDet.credit[0].code).ToString();

        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            if (OrderMethod.taken)
            {
                TakeAwayMsg takeAway = new TakeAwayMsg();
                takeAway.Show();
                this.Close();
            }
            else
            {
                OrderSuccesfullMsg orderMsg = new OrderSuccesfullMsg();
                orderMsg.Show();
                this.Close();
            }
             
            
        }
    }
}
