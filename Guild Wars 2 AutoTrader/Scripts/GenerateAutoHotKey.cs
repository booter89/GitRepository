using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Threading;
using Microsoft.Practices.Prism.Commands;
using System.IO;
using System.Collections.ObjectModel;
using Guild_Wars_2_AutoTrader.Utilities;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace Guild_Wars_2_AutoTrader.Scripts
{
    public class GenerateAutoHotKey : INotifyPropertyChanged
    {
        #region Fields

        public BackgroundWorker worker = new BackgroundWorker();
        private ObservableCollection<int> item_ids;

        private int progress;
        private bool scriptGenerationInProgress = false;

        private ObservableCollection<LogItem> log;
        private LogItem logItem = new LogItem();

        private string progressText;
        private string imageSource;
        private string logMessage;

        private string parentFolder;
        private string childFolder;
        private string folderPath;
        private string fileName;
        private string filePath;

        private bool canRemoveAll;
        private bool canBuyAndSell;
        private bool canBuyWeapon;
        private bool canRemoveOrder;
        private bool canSellWeapon;
        
        #endregion

        #region Constructors
        public GenerateAutoHotKey()
        {
            this.GenerateScriptCommand = new DelegateCommand(ExecuteScriptGeneration, CanGenerate);
            this.item_ids = new ObservableCollection<int>();
            this.log = new ObservableCollection<LogItem>();
            
        }

        #endregion

        #region Finalizers(Destructors)

        #endregion

        #region Delegates

        public DelegateCommand GenerateScriptCommand { get; set; }
        public delegate void AsyncCompletedEventHandler(object sender);

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        public event AsyncCompletedEventHandler ScriptComplete;

        #endregion

        #region Enums

        #endregion

        #region Interfaces

        #endregion

        #region Properties

        public ObservableCollection<int> Item_Ids
        {
            get { return item_ids; }
            set
            {
                item_ids = value;
                RaisePropertyChanged("ItemIdsAdded");
            }
        }
        
        public ObservableCollection<LogItem> Log
        {
            get { return log; }
            set
            {
                log = value;
                RaisePropertyChanged("LoggedWeapons");
                //GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public LogItem LogItem
        {
            get { return logItem; }
            set
            {
                logItem = value;
                log.Add(value);
                RaisePropertyChanged("ItemIdsAdded");
                //GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public bool ScriptGenerationInProgress
        {
            get { return scriptGenerationInProgress; }
            set
            {
                scriptGenerationInProgress = value;     
                RaisePropertyChanged("ScriptGenerationInProgress");
                //GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public int Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                RaisePropertyChanged("Progress");
            }
        }

        private static int CalculateProgress(int total, int complete)
        {
            // avoid divide by zero error
            if (total == 0) return 0;
            // calculate percentage complete
            var result = (double)complete / (double)total;
            var percentage = Math.Ceiling(result * 100.0);

            // make sure result is within bounds and return as integer;
            return Math.Max(0, Math.Min(100, (int)percentage));
        }
        
        public string ProgressText
        {
            get { return progressText; }
            set
            {
                progressText = value;
                RaisePropertyChanged("ProgressText");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }
        
        public string ParentFolder
        {
            get { return parentFolder; }
            set
            {
                parentFolder = value;
                RaisePropertyChanged("ParentFolder");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public string ChildFolder
        {
            get { return childFolder; }
            set
            {
                childFolder = value;
                RaisePropertyChanged("ChildFolder");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public string FolderPath
        {
            get { return folderPath; }
            set
            {
                folderPath = value;
                RaisePropertyChanged("FolderPath");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                RaisePropertyChanged("FileName");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                RaisePropertyChanged("FilePath");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }
        
        public bool CanRemoveAll
        {
            get { return canRemoveAll; }
            set
            {
                canRemoveAll = value;
                RaisePropertyChanged("CanRemoverAll");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public bool CanBuyAndSell
        {
            get { return canBuyAndSell; }
            set
            {
                canBuyAndSell = value;
                RaisePropertyChanged("CanBuyAndSell");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public bool CanBuyWeapon
        {
            get { return canBuyWeapon; }
            set
            {
                canBuyWeapon = value;
                RaisePropertyChanged("CanBuyWeapon");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public bool CanRemoveOrder
        {
            get { return canRemoveOrder; }
            set
            {
                canRemoveOrder = value;
                RaisePropertyChanged("CanRemoveOrder");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public bool CanSellWeapon
        {
            get { return canSellWeapon; }
            set
            {
                canSellWeapon = value;
                RaisePropertyChanged("CanSellWeapon");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public string ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                RaisePropertyChanged("ImageSource");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public string LogMessage
        {
            get { return logMessage; }
            set
            {
                logMessage = value;
                RaisePropertyChanged("LogMessage");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        public int TotalIndex
        {
            get { return totalIndex; }
            set
            {
                totalIndex = value;
            }
        }

        public int CurrentAction
        {
            get { return currentAction; }
            set
            {
                currentAction = value;
                RaisePropertyChanged("CurrentAction");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }
        
        public int TotalActions
        {
            get { return totalActions; }
            set
            {
                totalActions = value;
                RaisePropertyChanged("TotalActions");
                GenerateScriptCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Indexers
        private int totalIndex;
        private int currentAction;
        private int totalActions;

        #endregion

        #region Methods

        public bool CanGenerate()
        {
            return scriptGenerationInProgress;
            //(!string.IsNullOrEmpty(parentFolder) &&
            //!string.IsNullOrEmpty(Destination) &&

        }

        public void ExecuteScriptGeneration()
        {
            worker.DoWork += new DoWorkEventHandler(ScriptGeneration_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(scriptGeneration_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(ScriptGeneration_ProgressChanged);
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }

        public void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                var eventArgs = new PropertyChangedEventArgs(propertyName);
                handler(this, eventArgs);
            }
        }

        public void ScriptGeneration_DoWork(object sender, DoWorkEventArgs e)
        {
            #region Directory and Files 
            //Locate Files and Folders for the Template to be pulled and pushed to

            string folderName = Entities.Constants.scriptTopFolder;
            string subfolder = DateTime.Now.ToString("MMddyyyy");
            string pathString = System.IO.Path.Combine(folderName, subfolder);
            string fileName = String.Format("GW2_Auto_Trader_{0}.ahk", DateTime.Now.ToString("MMddyyyy_HHmmss"));
            string filePath = System.IO.Path.Combine(pathString, fileName);
            string scriptTemplateFile = Entities.Constants.scriptTemplate;

            //Check to see if Template File exists, if not return;
            if (!System.IO.File.Exists(scriptTemplateFile))
            {
                MessageBox.Show("Template File Missing", "Template File Missing", MessageBoxButton.OK);
                return;
            }

            if (!System.IO.Directory.Exists(pathString))
            {
                System.IO.Directory.CreateDirectory(pathString);
            }

            #endregion

            this.currentAction = 0;
            this.totalActions = 0;

            var worker = sender as BackgroundWorker;

            //this.scriptGenerationInProgress = true;

            this.progressText = "Script Generation Started";

            //LogItem logItem = new LogItem(this.progressText, "", "");

            worker.ReportProgress(1);
            
            //create a list of weapon ids from the constants class
            foreach (var weapon in Entities.Constants.item_ids)
            {
                this.Item_Ids.Add(weapon);
            }

            //Update total actions
            this.totalActions = item_ids.Count + 1;

            //Create a List of Lists of type weapon 
            List<List<Entities.Weapon>> weapons = new List<List<Entities.Weapon>>();

            //Add the 4 sub lists to the weapons lists of lists
            for (int i = 0; i < 4; i++)
            {
                weapons.Add(new List<Entities.Weapon>());
            }

            //Get the type of data to be fetched
            string getType = Enum.GetName(typeof(Entities.Constants.getType), 0);

            //Create waepon, fetch Guild Wars 2 Live data, and assign the weapon to the correct List
            foreach (var item_id in item_ids)
            {
                Entities.Weapon weapon = new Entities.Weapon(item_id, getType);

                if (this.currentAction < Entities.Constants.acCount)
                {
                    weapons[0].Add(weapon);
                }
                else if (this.currentAction < Entities.Constants.a_gCount)
                {
                    weapons[1].Add(weapon);
                }
                else if (this.currentAction < Entities.Constants.a_rCount)
                {
                    weapons[2].Add(weapon);
                }
                else
                {
                    weapons[3].Add(weapon);
                }

                this.currentAction++;

                #region ReportProgress

                this.progressText = getProgressText(this.currentAction, this.totalActions);

                this.imageSource = weapon.icon;

                this.logMessage = weapon.name;

                this.logItem = new LogItem(this.progressText, this.logMessage, this.imageSource);

                worker.ReportProgress(CalculateProgress(this.totalActions, this.currentAction), this.logItem);

                #endregion
            }

            List<string> canBuyLists = new List<string>();
            List<string> goldList = new List<string>();
            List<string> silverList = new List<string>();
            List<string> quantityList = new List<string>();
            List<List<string>> weaponIsBuyGoldSilverQuantity = new List<List<string>>();

            
            //worker.ReportProgress(CalculateProgress(this.totalActions, this.currentAction++), this.progressText);
            canBuyLists = getCanBuyItemList(weapons);

            int buyCount = 0;

            foreach (string list in canBuyLists)
            {
                foreach(char x in list)
                {
                    if(x.ToString() == "1")
                    {
                        buyCount++;
                    }
                }
            }

            //worker.ReportProgress(CalculateProgress(this.totalActions, this.currentAction++), this.progressText);
            goldList = getGoldList(weapons);

            //worker.ReportProgress(CalculateProgress(this.totalActions, this.currentAction++), this.progressText);
            silverList = getSilverList(weapons);

            //worker.ReportProgress(CalculateProgress(this.totalActions, this.currentAction++), this.progressText);
            quantityList = getQuantityList(weapons);

            weaponIsBuyGoldSilverQuantity.Add(canBuyLists);
            weaponIsBuyGoldSilverQuantity.Add(goldList);
            weaponIsBuyGoldSilverQuantity.Add(silverList);
            weaponIsBuyGoldSilverQuantity.Add(quantityList);

            List<bool> optionsList = new List<bool>();

            optionsList.Add(canRemoveAll);
            optionsList.Add(canBuyAndSell);
            optionsList.Add(canBuyWeapon);
            optionsList.Add(canRemoveOrder);
            optionsList.Add(canSellWeapon);

            //Read then Copy Template file to the new script file
            //Add variables
            using (System.IO.StreamReader templateFile = new System.IO.StreamReader(scriptTemplateFile))            
            using ( System.IO.StreamWriter scriptFile = new System.IO.StreamWriter(filePath, append: false))
            {
                scriptFile.WriteLine("totalIndex := " + totalIndex.ToString());
                scriptFile.WriteLine();
                scriptFile.WriteLine("canRemoveAllOrders := " + optionsList[0].ToString());
                scriptFile.WriteLine("canBuySellWeapons := " + optionsList[1].ToString());
                scriptFile.WriteLine("canBuyWeapon := " + optionsList[2].ToString());
                scriptFile.WriteLine("canRemoveOrders := " + optionsList[3].ToString());
                scriptFile.WriteLine("canSellWeapon := " + optionsList[4].ToString());
                scriptFile.WriteLine();
                scriptFile.WriteLine("BuyCount := ((Ceil(" + buyCount.ToString() +"/ 100) * 100) / 200) - 1");
                scriptFile.WriteLine();

                string text;

                int i = 0, j = 0;
                
                foreach (List<string> requirements in weaponIsBuyGoldSilverQuantity)
                {
                    i = 0;
                    foreach (string list in requirements)
                    {
                        text = Entities.Constants.listPrefix[i] + Entities.Constants.listMixfix[j] + "Array := [" + list + "]";
                        scriptFile.WriteLine(text);
                        i++;
                    }
                    scriptFile.WriteLine();
                    j++;
                }
                
                scriptFile.Write(templateFile.ReadToEnd());
                
            }
            
            this.currentAction++;

            #region Report Progress

            this.progressText = getProgressText(this.currentAction, this.totalActions);

            this.imageSource = "";

            this.logMessage = "The Script File Has been Generated!";

            this.logItem = new LogItem(this.progressText, this.logMessage, this.imageSource);

            worker.ReportProgress(CalculateProgress(this.totalActions, this.currentAction), this.logItem);

            #endregion


        }

        public List<string> getCanBuyItemList(List<List<Entities.Weapon>> weapons)
        {
            List<string> buyList = new List<string>();

            string zeroOrone = "";

            int j = 0;
            foreach (List<Entities.Weapon> weaponSubList in weapons)
            {
                string canBuyList = "";
                j = 0;
                foreach (Entities.Weapon weapon in weaponSubList)
                {
                    if (weapon.canBuyItem())
                    {
                        zeroOrone = "1";
                    }
                    else
                    {
                        zeroOrone = "0";
                    }

                    if (j != weaponSubList.Count - 1)
                    {
                        canBuyList = canBuyList + zeroOrone + ",";
                    }
                    else
                    {
                        canBuyList = canBuyList + zeroOrone;
                    }

                    j++;


                }
                buyList.Add(canBuyList);
            }
            return buyList;
        }

        public List<string> getGoldList(List<List<Entities.Weapon>> weapons)
        {
            List<string> goldList = new List<string>();

            int j = 0;
            string list = "";

            foreach (List<Entities.Weapon> weaponSubList in weapons)
            {
                list = "";
                j = 0;
                foreach (Entities.Weapon weapon in weaponSubList)
                {
                    if (j != weaponSubList.Count - 1)
                    {
                        list = list + weapon.gold.ToString() + ",";
                    }
                    else
                    {
                        list = list + weapon.gold.ToString();
                    }
                    j++;
                }
                goldList.Add(list);
            }
            return goldList;
        }

        public List<string> getSilverList(List<List<Entities.Weapon>> weapons)
        {
            List<string> silverList = new List<string>();
            int j = 0;
            string list = "";

            foreach (List<Entities.Weapon> weaponSubList in weapons)
            {
                list = "";
                j = 0;
                foreach (Entities.Weapon weapon in weaponSubList)
                {

                    if (j != weaponSubList.Count - 1)
                    {
                        list = list + weapon.silver.ToString() + ",";
                    }
                    else
                    {
                        list = list + weapon.silver.ToString();
                    }
                    j++;
                }
                silverList.Add(list);
            }
            return silverList;
        }

        public List<string> getQuantityList(List<List<Entities.Weapon>> weapons)
        {

            List<string> quantityList = new List<string>();
            int j = 0;
            string list = "";

            foreach (List<Entities.Weapon> weaponSubList in weapons)
            {
                list = "";
                j = 0;
                foreach (Entities.Weapon weapon in weaponSubList)
                {
                    if (j != weaponSubList.Count - 1)
                    {
                        list = list + weapon.buyQuantity.ToString() + ",";
                    }
                    else
                    {
                        list = list + weapon.buyQuantity.ToString();
                    }
                    j++;
                }
                quantityList.Add(list);
            }

            return quantityList;
        }

        private void ScriptGeneration_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Update Progress Complete Percentage
            this.Progress = e.ProgressPercentage;
   
            //Update Log Items
            if (!Object.ReferenceEquals(null,e.UserState))
            {
                if (e.UserState is bool)
                {
                    return;
                }

                this.LogItem = e.UserState as LogItem;

                if(this.log.Count > 1)
                {
                    int index = this.log.Count - 1;

                    if (Log[index].ImageSource != null)
                    {
                        this.ImageSource = Log[index].ImageSource;
                    }
                    if (Log[index].Message != null)
                    {
                        this.LogMessage = Log[index].Message;
                    }
                    if (Log[index].PercentMessage != null)
                    {
                        this.ProgressText = Log[index].PercentMessage;
                    }

                }
            }
            
        }

        private void scriptGeneration_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string complete = "Script Generation Complete!";
            string caption = "Script Generation";
            MessageBox.Show(complete, caption, MessageBoxButton.OK);
            
            this.Progress = 0;

            this.ScriptGenerationInProgress = false;

            this.Log.Clear();

            if (ScriptComplete != null)
            {
                ScriptComplete(this);
            }
        }

        public string getProgressText(int currentActions, int totalActions)
        {
            return String.Format(currentAction.ToString() + " of " + totalActions.ToString());
        }

        #endregion

        #region Structs

        #endregion

        #region Classes

        #endregion








    }
}