using Microsoft.UI.Xaml;
using System;

namespace WinUITheGameOfLife.Services;

public class DispatcherTimerAdapter : IDispatcherTimerAdapter
{
    private Action _timerAction;
    public DispatcherTimer _dispatcherTimer;
    public double DispatcherTimerInterval
    {
        get => _dispatcherTimer.Interval.TotalMilliseconds;
        set => _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(value);
    }

    public DispatcherTimerAdapter()
    {
        _dispatcherTimer = new DispatcherTimer();
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
    private void DispatcherTimer_Tick(object sender, object e)
    {
        _timerAction();
    }
}
