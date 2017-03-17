using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace Guild_Wars_2_AutoTrader.Utilities
{
    public class ThreadedTask
    {
        public ThreadedTask(Dispatcher UIDispacher = null)
        {
            this.UIDispatch = UIDispatch;
        }

        public Dispatcher UIDispatch { get; set; }
    }
}
