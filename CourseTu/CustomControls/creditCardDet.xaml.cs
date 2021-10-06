using CourseTu.Models;
using System;
using System.Collections.Generic;
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
using CourseTu.CustomControls;
using CourseTu.inside;

namespace CourseTu.CustomControls
{
    /// <summary>
    /// Interaction logic for creditCardDet.xaml
    /// </summary>
    public partial class creditCardDet : Window
    {
        public static List<creditCard> credit = new List<creditCard>();
        public creditCardDet()
        {
            InitializeComponent();

        }
        public  void setBorderColor(TextBoxWithPlaceHolder inputF, bool regexB)
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

            try
            {
                bool userNB = false;
                bool cardNoB = false;
                bool cvvB = false;
                bool dateB = false;

                condition = false;

                var userN = Name.Text;
                var cvv = Secode.Text;
                var cardNumber = cardNo.Text;
                var date = Date.Text;


                cardNoB = Regex.Match(cardNumber, "^\\d{0,16}$").Success;
                userNB = Regex.Match(userN, "^[A-Z][a-z]*(\\s[A-Z][a-z]*)+$").Success;
                dateB = Regex.Match(date, "^\\d{2}\\/\\d{4}$").Success;
                cvvB = Regex.Match(cvv, "\\d{3}").Success;

                setBorderColor(Name, userNB);
                setBorderColor(Secode, cvvB);
                setBorderColor(cardNo, cardNoB);
                setBorderColor(Date, dateB);


                if (cardNoB && userNB && dateB && cvvB)
                {

                    condition = true;
                }

                if (condition)
                {
                    
                    credit.Add(new creditCard { CardNumber = foramatCardNO(), Name = Name.Text, ExDate = Date.Text, code = Int32.Parse(Secode.Text) });
                    CreditCardUI credUI = new CreditCardUI();
                    credUI.Show();
                    this.Close();
                }

                else
                {

                    MessageBox.Show("Please check input fields", "Invalid", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Input All the Fields before Continuing", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            
          


        }
        private void OnClick(object sender, RoutedEventArgs e)
        {
            bool condition = false;
            do
            {
                RunValidations(condition);

            } while (condition);
            

           
        }
        public string foramatCardNO()
        {
            string cardNum = "";

             char[] cardNonumbers = (cardNo.Text).ToCharArray(); ;
             for (int i = 0;i<16;i++)
             {
                 cardNum = cardNum + cardNonumbers[i];
                 if (cardNum.Length ==4)
                 {
                     cardNum = cardNum + " ";
                 }
                 else if (cardNum.Length == 9)
                {
                    cardNum = cardNum + " ";
                }
                else if (cardNum.Length == 14)
                {
                    cardNum = cardNum + " ";
                }
            }
            return cardNum;
        }
    }
}
