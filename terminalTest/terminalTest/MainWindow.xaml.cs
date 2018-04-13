using System;
using System.IO;
using System.Text;
using System.Windows;
using terminalTest.Core;

namespace terminalTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int termEvent = 0;
        private Server server = new Server();
        private decimal amount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainForm_Loaded(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Hidden;

            server.readTerms();
            server.readCards();

            textBlock.Text = "\nДля совершения оплаты нажмите на зеленую кнопку";
        }

        void printCheck()
        {
            string[] arStr = File.ReadAllLines("../../database/transaction.txt", Encoding.GetEncoding("windows-1251"));
            textBlockCheck.Text = arStr[arStr.Length - 1];
        }

        #region CONTROL BUTTONS

        private void TermBtn_OK_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 0:
                    textBlock.Text = "\nВведите сумму для оплаты ";
                    termEvent++;
                    break;

                case 1:
                    if (textEnter.Text != "")
                    {
                        textBlock.Text = string.Format("\n сумма к оплаты \n{0} \nПродолжить?", textEnter.Text);
                        amount = decimal.Parse(textEnter.Text.Replace('.',','));
                    }
                    else
                    {
                        textBlock.Text = "Сумма введена неверно";
                        termEvent = -1;
                    }

                    textEnter.Text = "";
                    termEvent++;
                    break;

                case 2:
                    textBlock.Text = "\nВведите пин-код";
                    passwordBox.Visibility = Visibility.Visible;
                    termEvent++;
                    break;

                case 3:
                    textBlock.Text = "\n";
                    textBlock.Text += server.getRequest(5412751234123456, "S.Morris",
                        Convert.ToInt32(passwordBox.Password), 1209, amount, string.Format("{0:M d h m}", DateTime.Now), 1);
                    passwordBox.Password = "";
                    passwordBox.Visibility = Visibility.Hidden;
                    termEvent++;
                    if (textBlock.Text == "\nОперация прошла успешно")
                    {
                        printCheck();
                    }
                    
                    break;
            }
        }

        private void TermBtn_Del_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 3:
                    passwordBox.Password = "";
                    break;
            }
            textEnter.Text = "";
        }

        private void TermBtn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 3:
                    passwordBox.Password = "";
                    break;
            }
            passwordBox.Visibility = Visibility.Hidden;
            termEvent = 0;
            textBlock.Text = "\nДля совершения оплаты нажмите на зеленую кнопку";
            textEnter.Text = "";
        }

        #endregion CONTROL BUTTONS

        #region NUM BUTTONS

        private void TermBtn_1_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 1:
                    textEnter.Text += "1";
                    break;

                case 3:
                    if (passwordBox.Password.Length > 3)
                        break;
                    passwordBox.Password += "1";
                    break;
            }
        }

        private void TermBtn_2_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 1:
                    textEnter.Text += "2";
                    break;

                case 3:
                    if (passwordBox.Password.Length > 3)
                        break;
                    passwordBox.Password += "2";
                    break;
            }
        }

        private void TermBtn_3_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 1:
                    textEnter.Text += "3";
                    break;

                case 3:
                    if (passwordBox.Password.Length > 3)
                        break;
                    passwordBox.Password += "3";
                    break;
            }
        }

        private void TermBtn_4_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 1:
                    textEnter.Text += "4";
                    break;

                case 3:
                    if (passwordBox.Password.Length > 3)
                        break;
                    passwordBox.Password += "4";
                    break;
            }
        }

        private void TermBtn_5_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 1:
                    textEnter.Text += "5";
                    break;

                case 3:
                    if (passwordBox.Password.Length > 3)
                        break;
                    passwordBox.Password += "5";
                    break;
            }
        }

        private void TermBtn_6_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 1:
                    textEnter.Text += "6";
                    break;

                case 3:
                    if (passwordBox.Password.Length > 3)
                        break;
                    passwordBox.Password += "6";
                    break;
            }
        }

        private void TermBtn_7_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 1:
                    textEnter.Text += "7";
                    break;

                case 3:
                    if (passwordBox.Password.Length > 3)
                        break;
                    passwordBox.Password += "7";
                    break;
            }
        }

        private void TermBtn_8_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 1:
                    textEnter.Text += "8";
                    break;

                case 3:
                    if (passwordBox.Password.Length > 3)
                        break;
                    passwordBox.Password += "8";
                    break;
            }
        }

        private void TermBtn_9_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 1:
                    textEnter.Text += "9";
                    break;

                case 3:
                    if (passwordBox.Password.Length > 3)
                        break;
                    passwordBox.Password += "9";
                    break;
            }
        }

        private void TermBtn_0_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 1:
                    if (textEnter.Text == "")
                        break;
                    textEnter.Text += "0";
                    break;

                case 3:
                    if (passwordBox.Password.Length > 3)
                        break;
                    passwordBox.Password += "0";
                    break;
            }
        }

        private void TermBtn_Dot_Click(object sender, RoutedEventArgs e)
        {
            switch (termEvent)
            {
                case 1:
                    bool br = false;
                    char[] temp = textEnter.Text.ToCharArray();
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i] == '.')
                        {
                            br = true;
                        }
                    }
                    if (br)
                        break;
                    textEnter.Text += ".";
                    break;
            }
        }

        #endregion NUM BUTTONS
    }
}