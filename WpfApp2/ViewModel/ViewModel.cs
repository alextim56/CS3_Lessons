using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfTestMailSender.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Passwrd", typeof(string), typeof(WpfMailSender));

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Login"));
                }
            }
        }
        private string _passwrd;
        public string Passwrd
        {
            get { return _passwrd; }
            set
            {
                if (_passwrd != value)
                {
                    _passwrd = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Passwrd"));
                }
            }
        }
        public ICommand AccessCommand
        {
            get
            {
                return new DelegateCommand(Execute);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Execute(object obj)
        {
            if (Data.Check(_login, _passwrd) && obj is TabControl)
            {
                TabControl tc = obj as TabControl;
                tc.IsEnabled = true;
                tc.SelectedIndex = 1;
                foreach(TabItem tabItem in tc.Items)
                {
                    tabItem.IsEnabled = true;
                }
                updateHeader(tc);
                //TabItem tabItem = tc.Items[1] as TabItem;
                //tabItem.IsEnabled = true;
            }
        }

        public string FromMail { get; set; } = Data.MailSender;

        public string ToMail { get; set; } = Data.MailReciever;

        public string MailSubject { get; set; } = "Test";

        public string MailBody { get; set; } = "Some message to Bro!";

        private void ExecuteSend(object obj)
        {
            Data.MailPassword = System.IO.File.ReadAllText("C:\\temp\\2.txt");
            EmailSendServiceClass emailSendServiceClass = new EmailSendServiceClass();

            MessageWindow messageWindow = new MessageWindow();
            
            if (emailSendServiceClass.MailSend(FromMail, ToMail, MailSubject, MailBody, FromMail, Data.MailPassword))
            {
                messageWindow.tbMessage.Text = "Письмо успешно отправлено!";
                messageWindow.ShowDialog();
            }
            else
            {
                messageWindow.tbMessage.Text = "Ошибка отправки!";
                messageWindow.tbMessage.Foreground = Brushes.Red;
                messageWindow.ShowDialog();
            }
        }

        public DelegateCommand SendCommand
        {
            get
            {
                return new DelegateCommand(ExecuteSend);
            }
        }

        private string _nextTabName = "Далее";
        public string NextTabName
        {
            get { return _nextTabName; }
            set
            {
                if (_nextTabName != value)
                {
                    _nextTabName = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("NextTabName"));
                }
            }
        }

        private string _prevTabName = "Назад";
        public string PrevTabName
        {
            get { return _prevTabName; }
            set
            {
                if (_prevTabName != value)
                {
                    _prevTabName = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("PrevTabName"));
                }
            }
        }

        private int tabControlIndex = 0;
        public int TabControlIndex
        {
            get
            {
                return tabControlIndex;
            }
            set
            {
                if (tabControlIndex != value)
                {
                    tabControlIndex = value;
                    System.Diagnostics.Debug.WriteLine("TabControlIndex changed");
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TabControlIndex"));
                }
            }
        }

        private void updateHeader(TabControl tc)
        {
            int sel = tc.SelectedIndex;
            int nn = sel + 1;
            int pn = sel - 1;
            if (nn > tc.Items.Count - 1) nn = 0;
            if (pn < 0) pn = tc.Items.Count - 1;
            NextTabName = (tc.Items[nn] as TabItem).Header.ToString();
            PrevTabName = (tc.Items[pn] as TabItem).Header.ToString();
        }

        private void ExecuteNextTab(object obj)
        {
            if (obj is TabControl)
            {
                TabControl tc = obj as TabControl;
                int nextInd = TabControlIndex;
                if (TabControlIndex >= tc.Items.Count - 1)
                {
                    nextInd = 0;
                }
                else
                {
                    nextInd = TabControlIndex + 1;
                }
                if ((tc.Items[nextInd] as TabItem).IsEnabled)
                {
                    TabControlIndex = nextInd;
                    updateHeader(tc);
                }
            }
        }

        public ICommand TabNextCommand
        {
            get
            {
                return new DelegateCommand(ExecuteNextTab);
            }
        }

        private void ExecutePrevTab(object obj)
        {
            if (obj is TabControl)
            {
                TabControl tc = obj as TabControl;
                int nextInd = TabControlIndex;
                if (TabControlIndex == 0)
                {
                    nextInd = tc.Items.Count - 1;
                }
                else
                {
                    nextInd = TabControlIndex - 1;
                }
                if ((tc.Items[nextInd] as TabItem).IsEnabled)
                {
                    TabControlIndex = nextInd;
                    updateHeader(tc);
                }
            }
        }

        public ICommand TabPrevCommand
        {
            get
            {
                return new DelegateCommand(ExecutePrevTab);
            }
        }
    }
}
