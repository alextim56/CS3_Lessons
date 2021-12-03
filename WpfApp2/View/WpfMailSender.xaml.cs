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

        private void fileInpBox_FileNameChanged(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(fileInpBox.FileName);
        }

        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void TabSwitcher_btnNextClick(object sender, RoutedEventArgs e)
        //{
        //    if (tcTabContrl.SelectedIndex < tcTabContrl.Items.Count - 1)
        //    {
        //        tcTabContrl.SelectedIndex++;
        //        TabSwtchr.IsHidebtnPrevious = false;
        //        TabSwtchr.IsHideBtnNext = (tcTabContrl.SelectedIndex >= tcTabContrl.Items.Count - 1);
        //    }
        //}

        //private void TabSwitcher_btnPreviousClick(object sender, RoutedEventArgs e)
        //{
        //    if (tcTabContrl.SelectedIndex > 0)
        //    {
        //        tcTabContrl.SelectedIndex--;
        //        TabSwtchr.IsHideBtnNext = false;
        //        TabSwtchr.IsHidebtnPrevious = (tcTabContrl.SelectedIndex <= 0);
        //    }
        //}
    }
}
