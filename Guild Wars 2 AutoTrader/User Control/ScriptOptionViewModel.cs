using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Controls;


namespace Guild_Wars_2_AutoTrader.User_Control
{
    public class ScriptOptionViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private bool canRemoveAllOrdersCb;
        private bool canBuyAndSellCb;
        private bool canBuyWeaponsCb;
        private bool canRemoveBuyOrdersCb;
        private bool canSellWeaponsCb;

        public ScriptOptionViewModel()
        {

        }
        public bool CanRemoveAllOrdersCb
        {
            get { return canRemoveAllOrdersCb; }
            set
            {
                canRemoveAllOrdersCb = value;
                OnPropertyChanged("RACheckboxChecked");

            }
        }

        public bool CanBuyAndSellCb
        {
            get { return canBuyAndSellCb; }
            set
            {
                canBuyAndSellCb = value;
                OnPropertyChanged("BASCheckboxChecked");
            }
        }

        public bool CanBuyWeaponsCb
        {
            get { return canBuyWeaponsCb; }
            set
            {
                canBuyWeaponsCb = value;
                OnPropertyChanged("BWCheckboxChecked");
            }
        }

        public bool CanRemoveBuyOrdersCb
        {
            get { return canRemoveBuyOrdersCb; }
            set
            {
                canRemoveBuyOrdersCb = value;
                OnPropertyChanged("RBOCheckboxChecked");
            }
        }

        public bool CanSellWeaponsCb
        {
            get { return canSellWeaponsCb; }
            set
            {
                canSellWeaponsCb = value;
                OnPropertyChanged("SWCheckboxChecked");
            }
        }

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
