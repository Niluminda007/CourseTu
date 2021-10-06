using CourseTu.CustomControls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseTu.inside
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=MSI\USHA007; Initial Catalog=Tu; Integrated Security=True;");
        public Register()
        {
            InitializeComponent();
        }
        public static void setBorderColor(TextBoxWithPlaceHolder inputF,bool regexB)
        {

            if (regexB)
            {
                inputF.BorderBrush = Brushes.Green;
                inputF.BorderThickness = new Thickness(0, 0, 0, 2);
            }
            else
            {
                inputF.BorderBrush = Brushes.Red;
                inputF.BorderThickness = new Thickness(0, 0, 0, 2);
            }
        }




        public void RunValidations(bool condition)
        {


            bool userNB = false;
            bool passWB = false;
            bool firstNameB = false;
            bool lastNameB = false;
            bool emailB = false;
            bool PhoneNumberB = false;
            bool addressB = false;

            condition = false;

            var userN = UserName.Text;
            var passW = Password.Text;
            var email = emailadd.Text;
            var firstName = firstN.Text;
            var lastName = lastN.Text;
            var PhoneNumber = phoneNumber.Text;
            var address = Address.Text;




            try
            {
                userNB = Regex.Match(UserName.Text, "^[a-zA-Z0-9]([._-](?![._-])|[a-zA-Z0-9]){3,18}[a-zA-Z0-9]$").Success;
                passWB = Regex.Match(Password.Text, "^[a-zA-Z0-9]([._-](?![._-])|[a-zA-Z0-9]){3,18}[a-zA-Z0-9]$").Success;
                firstNameB = Regex.Match(firstN.Text, "^[A-Za-z][a-zA-Z]*$").Success;
                lastNameB = Regex.Match(lastN.Text, "^[A-Za-z][a-zA-Z]*$").Success;
                emailB = Regex.Match(emailadd.Text, "^(.+)@(.+)$").Success;
                PhoneNumberB = Regex.Match(phoneNumber.Text, "^[0-9]{8}$").Success;
                addressB = Regex.Match(Address.Text, "^.{1,50}$").Success;


                if (userNB && passWB && firstNameB && lastNameB && emailB && PhoneNumberB && addressB && Password.Text.Equals(conPassword.Text))
                {
                    condition = true;
                }

                setBorderColor(UserName, userNB);
                setBorderColor(Password, passWB);
                setBorderColor(emailadd, emailB);
                setBorderColor(firstN, firstNameB);
                setBorderColor(lastN, lastNameB);
                setBorderColor(phoneNumber, PhoneNumberB);
                setBorderColor(Address, addressB);
                setBorderColor(conPassword, Password.Text.Equals(conPassword.Text));
               



                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";
                try
                {
                    cnn.Open();
                    if (userNB && passWB && firstNameB && lastNameB && emailB && PhoneNumberB && addressB && Password.Text.Equals(conPassword.Text))
                    {
                        sql = $"Insert into tblUser (UserName,Password,FirstName,LastName,Address,EmailAddress,PhoneNumber) values('" + userN + "','" + passW + "','" + firstName + "','" + lastName + "','" + address + "','" + email + "','" + PhoneNumber + "')";

                        command = new SqlCommand(sql, cnn);

                        adapter.InsertCommand = new SqlCommand(sql, cnn);
                        adapter.InsertCommand.ExecuteNonQuery();

                        command.Dispose();

                        MessageBox.Show("Saved Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);

                        UserName.Text = "";
                        Password.Text ="";
                        conPassword.Text = "";
                        emailadd.Text = "";
                        firstN.Text = "";
                        lastN.Text = "";
                        phoneNumber.Text = "";
                        Address.Text = "";
                    }
                    else
                    {

                        MessageBox.Show("Please check the input fields", "Invalid", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cnn.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Please Input All the Fields to Continue", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);

            }




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            bool condition = false;
           
            do
            {

                RunValidations(condition);
                
            }
            while (condition);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void backClick(object sender, RoutedEventArgs e)
        {
           
           
            MainWindow mwin = new MainWindow();
            mwin.Show();
            this.Close();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
