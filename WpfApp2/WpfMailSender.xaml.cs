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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;


namespace WpfTestMailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

        private void btnSendMail_Click(object sender, RoutedEventArgs e)
        {
            string _password = System.IO.File.ReadAllText("C:\\temp\\2.txt");
            if (Library.MailSend(tbxFrom.Text, tbxTo.Text, tbxTopic.Text, tbxMessage.Text, tbxFrom.Text, _password))
            {
                MessageBox.Show("Письмо успешно отправлено!");
            }
            else
            {
                MessageBox.Show("Ошибка отправки!");
            }
        }
    }
}
