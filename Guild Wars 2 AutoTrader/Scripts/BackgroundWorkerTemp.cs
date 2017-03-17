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

namespace Guild_Wars_2_AutoTrader.Scripts
{
    public class BackgroundWorkerTemp : INotifyPropertyChanged
    {

        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;
        public BackgroundWorker worker = new BackgroundWorker();
        public DelegateCommand backgroundWorkerCommand { get; set; }

        private ObservableCollection<int> someCollection;
        private bool backgroundWorkerInProgress = false;
        private int progress;
        private string progressStep;

        private int currentAction;
        private int totalActions;

        #endregion

        #region Constructors

        public BackgroundWorkerTemp()
        {
            this.backgroundWorkerCommand = new DelegateCommand(ExecuteBackgroundWorker, CanGenerate);
            this.someCollection = new ObservableCollection<int>();
        }

        #endregion

        #region Finalizers(Destructors)

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        #endregion

        #region Interfaces

        #endregion

        #region Properties

        public ObservableCollection<int> SomeCollection
        {
            get { return someCollection; }
            set
            {
                someCollection = value;
                RaisePropertyChanged("ItemIdsAdded");
            }
        }

        public bool ScriptGenerationInProgress
        {
            get { return backgroundWorkerInProgress; }
            set
            {
                backgroundWorkerInProgress = value;
                RaisePropertyChanged("ScriptGenerationInProgress");
                backgroundWorkerCommand.RaiseCanExecuteChanged();
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

        public string ProgressStep
        {
            get { return progressStep; }
            set
            {
                progressStep = value;
                RaisePropertyChanged("CurrentActionText");
                backgroundWorkerCommand.RaiseCanExecuteChanged();
            }
        }

        private static int CalculateProgress(int total, int complete)
        {
            // avoid divide by zero error
            if (total == 0) return 0;
            // calculate percentage complete
            var result = (double)complete / (double)total;
            var percentage = result * 100.0;
            // make sure result is within bounds and return as integer;
            return Math.Max(0, Math.Min(100, (int)percentage));
        }

        public int CurrentAction
        {
            get { return currentAction; }
            set
            {
                currentAction = value;
                RaisePropertyChanged("CurrentAction");
                backgroundWorkerCommand.RaiseCanExecuteChanged();
            }
        }

        public int TotalActions
        {
            get { return totalActions; }
            set
            {
                totalActions = value;
                RaisePropertyChanged("TotalActions");
                backgroundWorkerCommand.RaiseCanExecuteChanged();
            }
        }


        #endregion

        #region Indexers

        #endregion

        #region Methods

        public bool CanGenerate()
        {
            return !backgroundWorkerInProgress;
            //(!string.IsNullOrEmpty(parentFolder) &&
            //!string.IsNullOrEmpty(Destination) &&

        }

        public void ExecuteBackgroundWorker()
        {
            worker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
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

        //Exicute Code in this method
        public void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            this.backgroundWorkerInProgress = true;
            worker.ReportProgress(0);
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Progress = e.ProgressPercentage;
            this.ProgressStep = e.UserState as string;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.backgroundWorkerInProgress = false;

            string complete = "Complete!";
            string caption = "Complete";
            MessageBox.Show(complete, caption, MessageBoxButton.OK);

        }
        

        #endregion

        #region Structs

        #endregion

        #region Classes

        #endregion
    }
}