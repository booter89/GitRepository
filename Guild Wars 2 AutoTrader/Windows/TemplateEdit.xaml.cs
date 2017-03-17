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
using System.IO;

namespace Guild_Wars_2_AutoTrader.Windows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TemplateEdit : Window
    {
        //Template File

        public string Path = Entities.Constants.scriptTemplate;

        public MainWindow ParentWindow;

        public TemplateEdit(MainWindow PW)
        {
            this.ParentWindow = PW;
            
            InitializeComponent();

            this.EditTb.Text = FileText(Path);
            this.EditTb.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            this.EditTb.TextWrapping = TextWrapping.Wrap;
            this.EditTb.AcceptsReturn = true;

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.ParentWindow.Activate();

            this.ParentWindow.canEnableButtons(true);

            this.Close();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.Save();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void Save()
        {
            using (StreamWriter file = new StreamWriter(Path))
            {
                file.Write(this.EditTb.Text);
            }

            MessageBox.Show("The Template File has been Saved", "File Saved", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
        }

        public string FileText(string path)
        {
            return File.ReadAllText(path);
        }

    }
}
