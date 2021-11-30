using Microsoft.Win32;
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
using System.Windows.Markup;


namespace ControlsLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    /// 

    [ContentProperty("FileName")]
    public partial class FileInputBox : UserControl
    {
        public static readonly DependencyProperty FileNameProperty = DependencyProperty.Register("FileName", typeof(string), typeof(FileInputBox));

        public static readonly RoutedEvent FileNameChangedEvent = EventManager.RegisterRoutedEvent("FileNameChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FileInputBox));

        public FileInputBox()
        {
            InitializeComponent();
            tbFilename.TextChanged += TbFilename_TextChanged;
        }

        private void TbFilename_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = true;
            //if (FileNameChanged != null)
            //    FileNameChanged(this, EventArgs.Empty);
            //גûחמג סמבûעטÿ
            RoutedEventArgs args = new RoutedEventArgs(FileNameChangedEvent);
            RaiseEvent(args);
        }

        public event RoutedEventHandler FileNameChanged
        {
            add { this.AddHandler(FileNameChangedEvent, value); }
            remove { this.RemoveHandler(FileNameChangedEvent, value); }
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog()==true)
            {
                this.FileName = dialog.FileName;
            }
        }

        public string FileName 
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); tbFilename.Text = value; }
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (oldContent != null)
                throw new InvalidOperationException("You can't change content!");
        }
    }
}