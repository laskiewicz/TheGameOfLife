using System;

namespace WPFTheGameOfLife.GameOfLife
{
    public class DispatcherTimerDeterministic : IDispatcherTimerAdapter
    {
        private Action _timerAction;
        public int Iterations { get; set; } = 1;
        public double DispatcherTimerInterval { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void Start()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _timerAction();
            }
        }
        public void SetTask(Action action)
        {
            _timerAction = action;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
        public void SetDispatcherTimerInterval(double timerInterval)
        {
            throw new NotImplementedException();
        }

    }
}
