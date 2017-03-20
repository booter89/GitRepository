using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.IO;
using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using Guild_Wars_2_AutoTrader.Scripts;
using System.Windows.Controls.Primitives;
using System.Collections.Specialized;
using Microsoft.Win32;
using System.Diagnostics;
using System.Net;

namespace Guild_Wars_2_AutoTrader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GenerateAutoHotKey ScriptDataContext;

        public User_Control.ScriptOptions optionsUC;

        public MainWindow()
        { 
            InitializeComponent();
            this.TaskbarItemInfo = new System.Windows.Shell.TaskbarItemInfo();

            if (isAPIWorking())
            {
                canEnableButtons(false);
            }

            ((INotifyCollectionChanged)LogList.Items).CollectionChanged += ListView_CollectionChanged;

        }
    
        private void ListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // scroll the new item into view   
                LogList.ScrollIntoView(e.NewItems[0]);
            }

            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                canEnableButtons(true);
                //canSelectChechbox(false);
            }
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        
        public void canEnableButtons(bool enable)
        {
            IEnumerable<Button> collection = this.MainGrid.Children.OfType<Button>();

            foreach (Button button in collection)
            {
                button.IsEnabled = enable;
            }
        }

        public void canSelectChechbox(bool select)
        {
            IEnumerable<CheckBox> collection = this.MainGrid.Children.OfType<CheckBox>();

            foreach (CheckBox checkbox in collection)
            {
                checkbox.IsChecked = select;
            }
        }

        public void Enable_Button(Button button)
        {
            button.IsEnabled = true;
        }

        public void Disable_Button(Button button)
        {
            button.IsEnabled = false;
        }

        private void SelectOptions(object sender, RoutedEventArgs e)
        {
            ScriptDataContext = new GenerateAutoHotKey();

            this.DataContext = ScriptDataContext;

            optionsUC = new User_Control.ScriptOptions(ScriptDataContext, this);

            this.MainGrid.Children.Add(optionsUC);

            optionsUC.SetValue(Grid.RowProperty, 1);
            optionsUC.SetValue(Grid.RowSpanProperty, 4);
            optionsUC.SetValue(Grid.ColumnProperty, 0);
            optionsUC.SetValue(Grid.ColumnSpanProperty, 6);

            canEnableButtons(false);

            optionsUC.Visibility = Visibility.Visible;
            
            optionsUC.RequestClose += OptionUC_RequestClose;

            ScriptDataContext.ScriptComplete += scriptComplete;
        }

        void OptionUC_RequestClose(object sender)
        {
            
            this.MainGrid.Children.Remove((UIElement)sender);
        }

        void scriptComplete(object sender)
        {
            canSelectChechbox(false);
            
            string folderName = Entities.Constants.scriptTopFolder;
            string subfolder = DateTime.Now.ToString("MMddyyyy");
            string pathString = System.IO.Path.Combine(folderName, subfolder);

            string complete = "The Auto Hot Key script is at: \n" + pathString ;
            string caption = "File Location";
            MessageBox.Show(complete, caption, MessageBoxButton.OK);
        }

        private void EditTemplateFile(object sender, RoutedEventArgs e)
        {
            canEnableButtons(false);

            Window editTemplateWindow = new Windows.TemplateEdit(this);
            
            editTemplateWindow.Visibility = Visibility.Visible;

            editTemplateWindow.Activate();
        }

        public bool isAPIWorking()
        {
            try
            {
                string uri = @"https://api.guildwars2.com/v2/items/27020";

                var request = WebRequest.Create(uri);
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        return true;
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return false;
                    }
                    else
                    {
                        // Do something else
                        return false;
                    }
                }
                else
                {
                    // Do something else
                    return false;
                }
            }
        }

    }
}
