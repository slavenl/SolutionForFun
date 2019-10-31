using System;
using System.Threading;

namespace WebApiService.TimerFeatures
{
    public class TimerManager
    {
        private readonly Timer _timer;
        private readonly AutoResetEvent _autoResetEvent;
        private readonly Action _action;

        public DateTime TimerStarted { get; }

        public TimerManager(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 4000, 8000);
            TimerStarted = DateTime.Now;
        }

        public void Execute(object stateInfo)
        {
            _action();

            if ((DateTime.Now - TimerStarted).Seconds > 100)
            {
                _timer.Dispose();
            }
        }
    }
}
