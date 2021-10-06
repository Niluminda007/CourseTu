using CourseTu.inside;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseTu.CustomControls;
using CourseTu.Models;
using CourseTu.Helpers;
using CourseTu.Messages;


namespace CourseTu.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        string pass;
        public static List<UserModel> user = new List<UserModel>();
        public LoginPage()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=MSI\USHA007; Initial Catalog=Tu; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM tblUser WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", Nameid.Text);
                var pass = Passid.Text;
                sqlCmd.Parameters.AddWithValue("@Password", Passid.Text);

             
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Nameid.BorderBrush = Brushes.Green;
                    Nameid.BorderThickness = new Thickness(0, 0, 0, 2);
                    Passid.BorderBrush = Brushes.Green;
                    Passid.BorderThickness = new Thickness(0, 0, 0, 2);
                    user.Add(new UserModel() { username = Nameid.Text, password = Passid.Text });
                    meuView m1 = new meuView();
                    m1.Show();
                    Application.Current.Windows[0].Close();



                }
                else
                {
                    
                    Nameid.BorderBrush = Brushes.Red;
                    Nameid.BorderThickness = new Thickness(0, 0, 0, 2);
                    Passid.BorderBrush = Brushes.Red;
                    Passid.BorderThickness = new Thickness(0, 0, 0, 2);
                    MessageBox.Show("Incorrect Login Data", "Invalid", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                }
            }
            catch (Exception ex)
            {
                Nameid.BorderBrush = Brushes.Red;
                Nameid.BorderThickness = new Thickness(0, 0, 0, 2);
                Passid.BorderBrush = Brushes.Red;
                Passid.BorderThickness = new Thickness(0, 0, 0, 2);
                MessageBox.Show("Please check your credentials", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            finally
            {
                sqlCon.Close();
            }
        }
        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            Application.Current.Windows[0].Close();

        }
    }
}
