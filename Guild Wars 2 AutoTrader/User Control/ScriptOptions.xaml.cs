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
using Guild_Wars_2_AutoTrader.Scripts;
using Guild_Wars_2_AutoTrader.Entities;

using System.ComponentModel;

namespace Guild_Wars_2_AutoTrader.User_Control
{
    /// <summary>
    /// Interaction logic for ScriptOptions.xaml
    /// </summary>
    public partial class ScriptOptions : UserControl
    {
        //The main parent window that hosts this user control
        public MainWindow ParentWindow;

        //The instance of the GenerateAutoHotKey that this user control is working with
        public  GenerateAutoHotKey GenerateAutoHotKey;

        //Event Handler to trigger a request user control close event on the partent window
        public delegate void RequestCloseEventHandler(object sender);
        public event RequestCloseEventHandler RequestClose;

        //public event PropertyChangedEventHandler PropertyChanged;


        public ScriptOptions(GenerateAutoHotKey GenerateAutoHotKey, MainWindow p)
        {
            this.ParentWindow = p;

            this.GenerateAutoHotKey = GenerateAutoHotKey;

            this.DataContext = GenerateAutoHotKey;

            InitializeComponent();

            GenerateScriptBtn.IsEnabled = false;

        }
        
        private void CheckBox_isEnabledChanged()
        {
            if ((RemoveAllOrdersCb.IsChecked == false) && BuyAndSellCb.IsChecked == false && BuyWeaponsCb.IsChecked == false && RemoveBuyOrdersCb.IsChecked == false && SellWeaponsCb.IsChecked == false)
            {
                GenerateScriptBtn.IsEnabled = false;
            }
            else
            {
                GenerateScriptBtn.IsEnabled = true;
            }
        }

        #region button Click Events

        private void RemoveAllOrdersCb_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox_isEnabledChanged();
        }

        private void BuyAndSellCb_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox_isEnabledChanged();

            if (BuyAndSellCb.IsChecked == false)
            {
                BuyWeaponsCb.IsEnabled = false;
                RemoveBuyOrdersCb.IsEnabled = false;
                SellWeaponsCb.IsEnabled = false;

                //BuyWeaponsCb.Visibility = Visibility.Collapsed;
                //RemoveBuyOrdersCb.Visibility = Visibility.Collapsed;
                //SellWeaponsCb.Visibility = Visibility.Collapsed;

                BuyWeaponsCb.IsChecked = false;
                RemoveBuyOrdersCb.IsChecked = false;
                SellWeaponsCb.IsChecked = false;
            }
            else
            {
                //BuyWeaponsCb.Visibility = Visibility.Visible;
                BuyWeaponsCb.IsEnabled = true;
                if (BuyWeaponsCb.IsChecked == true)
                {
                    //RemoveBuyOrdersCb.Visibility = Visibility.Visible;
                    RemoveBuyOrdersCb.IsEnabled = true;
                    IndexTb.Text = "Index: 1";
                    this.GenerateAutoHotKey.TotalIndex = 1;

                }
                else
                {
                    //RemoveBuyOrdersCb.Visibility = Visibility.Collapsed;
                    RemoveBuyOrdersCb.IsEnabled = false;
                }
                //SellWeaponsCb.Visibility = Visibility.Visible;
                SellWeaponsCb.IsEnabled = true;
            }
        }

        private void BuyWeaponsCb_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox_isEnabledChanged();

            if (BuyWeaponsCb.IsChecked == true)
            {
                //RemoveBuyOrdersCb.Visibility = Visibility.Visible;
                RemoveBuyOrdersCb.IsEnabled = true;
                IndexTb.Text = "Index: 1";
                this.GenerateAutoHotKey.TotalIndex = 1;

            }
            else
            {
                //RemoveBuyOrdersCb.Visibility = Visibility.Collapsed;
                RemoveBuyOrdersCb.IsEnabled = false;
                RemoveBuyOrdersCb.IsChecked = false;
                if (BuyWeaponsCb.IsChecked == false && SellWeaponsCb.IsChecked == true)
                {
                    IndexTb.Text = "Index: 551";
                    this.GenerateAutoHotKey.TotalIndex = 551;
                }

            }
        }

        private void RemoveBuyOrdersCb_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox_isEnabledChanged();
        }

        private void SellWeaponsCb_Changed(object sender, RoutedEventArgs e)
        {
            CheckBox_isEnabledChanged();

            if (BuyWeaponsCb.IsChecked == true && SellWeaponsCb.IsChecked == true)
            {
                IndexTb.Text = "Index: 1";
                this.GenerateAutoHotKey.TotalIndex = 1;
            }
            else if (BuyWeaponsCb.IsChecked == false && SellWeaponsCb.IsChecked == true)
            {
                IndexTb.Text = "Index: 551";
                this.GenerateAutoHotKey.TotalIndex = 551;
            }
            else
            {
                IndexTb.Text = "Index: 1";
                this.GenerateAutoHotKey.TotalIndex = 1;
            }
        }

        private void GenerateScriptBtn_Click(object sender, RoutedEventArgs e)
        {
            this.ParentWindow.canEnableButtons(false);

            this.GenerateAutoHotKey.ScriptGenerationInProgress = true;

            this.GenerateScriptBtn.Command = this.GenerateAutoHotKey.GenerateScriptCommand;

            if (RequestClose != null)
            {
                RequestClose(this);
            }
        }

        #endregion

    }
}

