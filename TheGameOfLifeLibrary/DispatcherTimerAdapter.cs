using System;

namespace TheGameOfLifeLibrary
{
    public class DispatcherTimerAdapter : IDispatcherTimerAdapter
    {
        private Action _timerAction;
        public System.Windows.Threading.DispatcherTimer _dispatcherTimer;
        public double DispatcherTimerInterval
        {
            get => _dispatcherTimer.Interval.TotalMilliseconds;
            set => _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(value);
        }

        public DispatcherTimerAdapter()
        {
            _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        }

        public void SetTask(Action action)
        {
            _timerAction = action;
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
        }
        public void Start()
        {
            _dispatcherTimer.Start();
        }
        public void Stop()
        {
            _dispatcherTimer.Stop();
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            _timerAction();
        }
    }
}
