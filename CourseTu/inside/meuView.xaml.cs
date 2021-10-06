using CourseTu.Models;
using CourseTu.Helpers;
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
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;




namespace CourseTu.inside
{
    /// <summary>
    /// Interaction logic for meuView.xaml
    /// </summary>
    public partial class meuView : Window
    {
        public static List<product> specialProduct = new List<product>();
        public static List<product> Appatizers = new List<product>();
        public static List<product> comfortFood = new List<product>();
        public static List<product> pizza = new List<product>();
        public static List<product> kidsSpecial = new List<product>();
        public static List<product> desserts = new List<product>();
        public static List<product> beverages = new List<product>();
        public static List<product> cocktails = new List<product>();



        public product pro_data { get; set; }



        /// <summary>
        /// Test 
        /// </summary>
        /// <param name="stu"></param>
        /// <param name="tblname"></param>
        public static void AddproductToList(List<product> stu,string tblname)
        {
            
            SqlConnection sqlCon = new SqlConnection(@"Data Source=MSI\USHA007; Initial Catalog=Tu; Integrated Security=True;");
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            using (sqlCon) {

                SqlCommand command1 = new SqlCommand(
                  $"SELECT Name,path,price FROM {tblname};",
                    sqlCon);



                SqlDataReader reader1 = command1.ExecuteReader();

                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        stu.Add(new product() { image = toBitmap(File.ReadAllBytes(@reader1.GetString(1))), pro_name = reader1.GetString(0), price = Convert.ToDouble(reader1.GetString(2)) });

                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader1.Close();
            }
            
        }


        public static void AddColumns(DataGrid dt)
        {
            var factory = new FrameworkElementFactory(typeof(Image));
            Binding bind = new Binding("image");
            factory.SetValue(Image.SourceProperty, bind);
            DataTemplate cellTemplate = new DataTemplate() { VisualTree = factory };
            DataGridTemplateColumn imgCol = new DataGridTemplateColumn()
            {
                Header = "Preview",
                CellTemplate = cellTemplate
            };
            dt.Columns.Add(imgCol);


            dt.Columns.Add(new DataGridTextColumn()
            {
                Header = "product name",
                Binding = new Binding("pro_name")
            });
           
            
            dt.Columns.Add(new DataGridTextColumn()
            {
                Header = "product price",
                Binding = new Binding("price")
            });
        }

       

        public meuView()
        {

            InitializeComponent();

            pro_data = new product();
             
            AddproductToList(specialProduct,"special");
            AddproductToList(Appatizers,"appatizers");
            AddproductToList(comfortFood, "comfort");
            AddproductToList(pizza, "pizza");
            AddproductToList(kidsSpecial, "kids");
            AddproductToList(desserts, "deserts");
            AddproductToList(beverages, "beverages");
            AddproductToList(cocktails, "cocktails");

            AddColumns(dt);
            AddColumns(dt1);
            AddColumns(dataG);
            AddColumns(dt3);
            AddColumns(dt4);
            AddColumns(dt5);
            AddColumns(dt6);
            AddColumns(dt7);

            dt.ItemsSource = specialProduct;
            dt1.ItemsSource = Appatizers;
            dataG.ItemsSource = comfortFood;
            dt3.ItemsSource = pizza;
            dt4.ItemsSource = kidsSpecial;
            dt5.ItemsSource = desserts;
            dt6.ItemsSource = beverages;
            dt7.ItemsSource = cocktails;




        }
        public static BitmapImage toBitmap(Byte[] value)
        {
            if (value != null && value is byte[])
            {
                byte[] ByteArray = value as byte[];
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(ByteArray);
                bmp.EndInit();
                return bmp;
            }
            return null;
        }


       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {          
                dynamic row = 0;

                if (tab.IsSelected)
                {
                    if (dt.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Please Select a product", "Select", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    }
                    else
                    {
                        row = dt.SelectedItems;
                    }
                
                }
                    

                else if (tab1.IsSelected)
                {
                    if (dt1.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Please Select a product", "Select", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    }
                    else
                    {
                        row = dt1.SelectedItems;
                    }
                
                }

                else if (tab2.IsSelected)
                {
                    if (dataG.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Please Select a product", "Select", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    }
                    else
                    {
                        row = dataG.SelectedItems;
                    }

                }

            else if (tab3.IsSelected)
            {
                if (dt3.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please Select a product", "Select", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
                else
                {
                    row = dt3.SelectedItems;
                }

            }

            else if (tab4.IsSelected)
            {
                if (dt4.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please Select a product", "Select", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
                else
                {
                    row = dt4.SelectedItems;
                }

            }

            else if (tab5.IsSelected)
            {
                if (dt5.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please Select a product", "Select", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
                else
                {
                    row = dt5.SelectedItems;
                }

            }

            else if (tab6.IsSelected)
            {
                if (dt6.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please Select a product", "Select", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
                else
                {
                    row = dt6.SelectedItems;
                }

            }

            else if (tab7.IsSelected)
            {
                if (dt7.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please Select a product", "Select", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
                else
                {
                    row = dt7.SelectedItems;
                }

            }

                string sname = row[0].pro_name;
                double pr = row[0].price;

                List<cartItems> cart = new List<cartItems>();

                try

                {
                    if (Convert.ToInt32(proN.Text) > 0 && Convert.ToInt32(proN.Text)<50)
                    {

                        cart.Add(new cartItems { pro_name = sname, price = pr, quantity = Convert.ToInt32(proN.Text) });

                        lbTodoList.Items.Add(cart);
                        proN.Clear();
                    }
                    else if (Convert.ToInt32(proN.Text) < 0 || Convert.ToInt32(proN.Text) > 50)
                    {
                        MessageBox.Show("We are sorry aren't able to process this much of products at once", "Sorry", MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Select a Valid Quantity", "Check Again", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    proN.Clear();
                }

        }

            catch (Exception ex)
            {
               
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(lbTodoList.SelectedItems.Count == 0)
            {
                MessageBox.Show("There are no items to remove", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            else
            {
                lbTodoList.Items.RemoveAt(lbTodoList.Items.IndexOf(lbTodoList.SelectedItem));
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dynamic cart = lbTodoList.Items;

            for (int i = 0; i < lbTodoList.Items.Count; i++)
            {
                cartItems ct = new cartItems();

                ct.pro_name = cart[i][0].pro_name;
                ct.quantity = cart[i][0].quantity;
                ct.price = cart[i][0].price;

                UserHelper.cart.Add(ct);

            }
            if (lbTodoList.Items.Count == 0)
            {
                MessageBox.Show("Please Select at least one product", "Are you Sure", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
            }
            else
            {
                OrderMethod om = new OrderMethod();
                om.Show();
                this.Close();

            }           
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;

            ICollectionView cv = null;
            if (tab.IsSelected)
                cv = CollectionViewSource.GetDefaultView(dt.ItemsSource);

            else if(tab1.IsSelected)
                cv = CollectionViewSource.GetDefaultView(dt1.ItemsSource);

            else if (tab2.IsSelected)
                cv = CollectionViewSource.GetDefaultView(dataG.ItemsSource);

            else if (tab3.IsSelected)
                cv = CollectionViewSource.GetDefaultView(dt3.ItemsSource);

            else if (tab4.IsSelected)
                cv = CollectionViewSource.GetDefaultView(dt4.ItemsSource);

            else if (tab5.IsSelected)
                cv = CollectionViewSource.GetDefaultView(dt5.ItemsSource);

            else if (tab6.IsSelected)
                cv = CollectionViewSource.GetDefaultView(dt6.ItemsSource);

            else if (tab7.IsSelected)
                cv = CollectionViewSource.GetDefaultView(dt7.ItemsSource);


            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    product p = o as product;
                    
                    return (p.pro_name.ToUpper().StartsWith(filter.ToUpper()));
                };
            }

        }

        private void lbTodoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    }
