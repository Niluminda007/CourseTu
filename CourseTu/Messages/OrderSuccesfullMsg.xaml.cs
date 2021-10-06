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

namespace CourseTu.Messages
{
    /// <summary>
    /// Interaction logic for OrderSuccesfullMsg.xaml
    /// </summary>
    public partial class OrderSuccesfullMsg : Window
    {
        public OrderSuccesfullMsg()
        {
            InitializeComponent();
        }

        private void onbtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWIn = new MainWindow();
            mainWIn.Show();
            this.Close();
        }
    }
}
