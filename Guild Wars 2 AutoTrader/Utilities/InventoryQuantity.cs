using Guild_Wars_2_AutoTrader.Entities;
using Microsoft.Practices.Prism.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Guild_Wars_2_AutoTrader.Scripts
{
    public class InventoryQuantity
    {
        public BackgroundWorker worker = new BackgroundWorker();
        public DelegateCommand inventoryQuantityCommand { get; set; }

        private bool inventoryQuantityInProgress = false;
        private int progress;



        public InventoryQuantity()
        {
            this.inventoryQuantityCommand = new DelegateCommand(ExecuteInventoryQuantity, CanGenerate);
        }

        public void InventoryQuantity_DoWork(object sender, DoWorkEventArgs e)
        {

            var worker = sender as BackgroundWorker;
            this.inventoryQuantityInProgress = true;
            worker.ReportProgress(1);

            string accessToken = "5AE5DE98-9A5B-0B4B-88CE-D2AD883779EC4FDDF32A-F5F6-482D-B524-41F32923C154";
            var url = "https://api.guildwars2.com/v2/characters/Phannie%20Bandit";

            using (var webClient = new System.Net.WebClient())
            {
                webClient.Headers.Add("Content-Type", "text");
                webClient.Headers[System.Net.HttpRequestHeader.Authorization] = "Bearer " + accessToken;
                var response = webClient.DownloadString(url);

                var PhannieBandit = JsonConvert.DeserializeObject<Character>(response);

                List<Bag> CompleteInventory = PhannieBandit.bags;

                List<List<Inventory>> Bags = new List<List<Inventory>>();

                foreach (Bag bag in CompleteInventory)
                {
                    Bags.Add(bag.getInventory());
                }

                List<Inventory> Slots = new List<Inventory>();

                foreach (List<Inventory> bagList in Bags)
                {
                    foreach (Inventory slot in bagList)
                    {
                        Slots.Add(slot);
                    }
                }
                
                CombineInventory combinedInventory = new CombineInventory(Slots);

                var orderedInventory = combinedInventory.combineInventory.OrderByDescending(inventory => inventory.count);

                string text = PhannieBandit.bags.ToString();

            }
        }

        private void InventoryQuantity_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Progress = e.ProgressPercentage;
        }

        private void InventoryQuantity_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.inventoryQuantityInProgress = false;

            string complete = "Script Generation Complete!";
            string caption = "Script Generation";
            MessageBox.Show(complete, caption, MessageBoxButton.OK);

        }
        public bool CanGenerate()
        {
            return !inventoryQuantityInProgress;
            //(!string.IsNullOrEmpty(parentFolder) &&
            //!string.IsNullOrEmpty(Destination) &&

        }

        public void ExecuteInventoryQuantity()
        {
            worker.DoWork += new DoWorkEventHandler(InventoryQuantity_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(InventoryQuantity_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(InventoryQuantity_ProgressChanged);
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
        public event PropertyChangedEventHandler PropertyChanged;

        public int Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                RaisePropertyChanged("Progress");
            }
        }

        public bool InventoryQuantityInProgress
        {
            get { return inventoryQuantityInProgress; }
            set
            {
                inventoryQuantityInProgress = value;
                RaisePropertyChanged("ScriptGenerationInProgress");
                inventoryQuantityCommand.RaiseCanExecuteChanged();
            }
        }

    }
}


