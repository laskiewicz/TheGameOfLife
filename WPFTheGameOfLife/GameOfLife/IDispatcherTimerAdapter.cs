using System;

namespace WPFTheGameOfLife.GameOfLife
{
    public interface IDispatcherTimerAdapter
    {
        double DispatcherTimerInterval { get; set; }
        void SetTask(Action action);
        void Start();
        void Stop();
    }
}