using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Guild_Wars_2_AutoTrader.Utilities
{
    //public class Log
    //{
    //    public Log()
    //    {
    //        this.Items = new ObservableCollection<LogItem>();
    //    }

    //    public ObservableCollection<LogItem> Items { get; set; }

    //    //public List<LogItem> Items { get; set; }
    //    //public event Log.LogChangedHandler LogChanged;
    //    public delegate void LogChangedHandler(Log Sender);

    //    public void AddLogItem(LogItem LogItem)
    //    {
    //        Items.Add(LogItem);

    //        //if (this.LogChanged != null)
    //        //{
    //        //    this.LogChanged(this);
    //        //}
    //    }

    //    public override string ToString()
    //    {
    //        StringBuilder myResult = new StringBuilder();

    //        foreach (LogItem item in this.Items)
    //        {
    //            myResult.AppendLine(String.Format("Item: ", item.Message.ToString()));
    //            //myResult.AppendLine(String.Format("{0}\t{1]\t{2}\t{3}", item.Time.ToString(), item.Type.ToString(), item.Severity.ToString(), item.Message.ToString()));
    //        }

    //        return myResult.ToString();

    //    }
    //}

    public class LogItem
    {
        //public ObservableCollection<string> Items = new ObservableCollection<string>();
        public LogItem()
        {

        }

        public LogItem(string percentMessage, string Message, string ImageSource)
        {
            //Items.Add(Message);
            this.PercentMessage = percentMessage;
            this.Message = Message;
            this.ImageSource = ImageSource;
            //this.Type = TypeCodes.Status;
            //this.Severity = SeverityCodes.Unknow;
            //this.Time = DateTime.Now;
        }
        //public LogItem(string Message, LogItem.TypeCodes Type, LogItem.SeverityCodes Severity = LogItem.SeverityCodes.Unknow)
        //{
        //    this.Message = Message;
            //this.Type = Type;
            //this.Severity = SeverityCodes.Unknow;
            //this.Time = DateTime.Now;

        //}
        public string ImageSource { get; set; }
        public string PercentMessage { get; set; }
        //public BitmapImage Image { get; set; }
        public string Message { get; set; }
        //public LogItem.SeverityCodes Severity { get; set; }
        //public Brush TextColor { get; set; }
        //public DateTime Time { get; set; }
        //public LogItem.TypeCodes Type {get; set;}

        public override string ToString()
        {
            //StringBuilder myResult = new StringBuilder();

            //foreach (string item in this.Items)
            //{
            //    myResult.AppendLine(String.Format("Weapon: {0}", item));
            //}
            return this.Message.ToString();
        }

        //public enum SeverityCodes
        //{
        //    Low = 0,
        //    Medium = 1,
        //    High = 2,
        //    Unknow = 3,
        //}

        //public enum TypeCodes
        //{
        //    Success = 0,
        //    Status = 1,
        //    Warning = 2,
        //    Error = 3,
        //}
    }
}
