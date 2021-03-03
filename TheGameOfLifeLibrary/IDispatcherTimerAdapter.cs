using System;

namespace TheGameOfLifeLibrary
{
    public interface IDispatcherTimerAdapter
    {
        double DispatcherTimerInterval { get; set; }
        void SetTask(Action action);
        void Start();
        void Stop();
    }
}