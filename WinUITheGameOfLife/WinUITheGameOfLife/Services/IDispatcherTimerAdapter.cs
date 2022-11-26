using System;

namespace WinUITheGameOfLife.Services;

public interface IDispatcherTimerAdapter
{
    double DispatcherTimerInterval { get; set; }
    void SetTask(Action action);
    void Start();
    void Stop();
}