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
            tbxFrom.Text = Data.MailSender;
            tbxTo.Text = Data.MailReciever;
        }

        private void btnSendMail_Click_1(object sender, RoutedEventArgs e)
        {
            string _password = System.IO.File.ReadAllText("C:\\temp\\2.txt");
            Data.MailPassword = System.IO.File.ReadAllText("C:\\temp\\2.txt");
            EmailSendServiceClass emailSendServiceClass = new EmailSendServiceClass();

            MessageWindow messageWindow = new MessageWindow();

            if (emailSendServiceClass.MailSend(tbxFrom.Text, tbxTo.Text, tbxTopic.Text, tbxMessage.Text, tbxFrom.Text, Data.MailPassword))
            {
                messageWindow.tbMessage.Text = "Письмо успешно отправлено!";
                messageWindow.ShowDialog();
                //MessageBox.Show("Письмо успешно отправлено!");
            }
            else
            {
                messageWindow.tbMessage.Text = "Ошибка отправки!";
                messageWindow.tbMessage.Foreground = Brushes.Red;
                messageWindow.ShowDialog();
                //MessageBox.Show("Ошибка отправки!");
            }
        }
    }
}
