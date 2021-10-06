using CourseTu.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using CourseTu.Models;
using CourseTu.Messages;

namespace CourseTu.inside.Delivery
{
    /// <summary>
    /// Interaction logic for delivery.xaml
    /// </summary>
    public partial class delivery : Window
    {
        public static List<DeliveryDetails> details = new List<DeliveryDetails>();
        public delivery()
        {
            InitializeComponent();

            string userName = LoginPage.user[0].username;
            string password = LoginPage.user[0].password;


            SqlConnection sqlCon = new SqlConnection(@"Data Source=MSI\USHA007; Initial Catalog=Tu; Integrated Security=True;");
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            using (sqlCon)
            {

                SqlCommand command1 = new SqlCommand(
                  $"SELECT FirstName,LastName,Address,EmailAddress,PhoneNumber FROM tblUser WHERE UserName='{userName}' AND Password='{password}' " ,
                    sqlCon);



                SqlDataReader reader1 = command1.ExecuteReader();

                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        details.Add(new DeliveryDetails() {firstName = @reader1.GetString(0) , lastName = @reader1.GetString(1), address = @reader1.GetString(2), email = @reader1.GetString(3),phoneNumber = reader1.GetString(4) });

                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader1.Close();
            }

            FirstName.Text = details[0].firstName;
            LastName.Text = details[0].lastName;
            address.Text = details[0].address;
            Email.Text = details[0].email;
            phoneN.Text = details[0].phoneNumber;

        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            CheckOut checkOut = new CheckOut();
            checkOut.Show();
            this.Close();
        }
    }
}
