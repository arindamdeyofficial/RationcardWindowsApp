using System;
using System.Collections.Generic;

namespace RationCard.Helper
{
    public static class ThreadHelper
    {
        private static System.Threading.Timer _timerThread;
        private static int _period = 5000;
        static ThreadHelper()
        {
            _timerThread = new System.Threading.Timer((o) =>
            {
                // Stop the timer;
                _timerThread.Change(-1, -1);

                // Process your data
                ProcessData();

                // start timer again (BeginTime, Interval)
                _timerThread.Change(_period, _period);
            }, null, 0, _period);
        }

        public static Func<Dictionary<DateTime, string[]>> ProcessData = null;
    }
}
