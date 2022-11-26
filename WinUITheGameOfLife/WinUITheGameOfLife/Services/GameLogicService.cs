using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TheGameOfLifeLibrary;
using TheGameOfLifeLibrary.Models;

namespace WinUITheGameOfLife.Services;

public class GameLogicService
{
    public GameLogicService(GameLogic gameLogic, IDispatcherTimerAdapter dispatcherTimerAdapter)
    {
        _gameLogic = gameLogic;
        _dispatcherTimerAdapter = dispatcherTimerAdapter;
        _dispatcherTimerAdapter?.SetTask(DispatcherTimer_Tick);
    }

    private IDispatcherTimerAdapter _dispatcherTimerAdapter;
    private GameLogic _gameLogic;

    public void StartSimulation()
    {
        _dispatcherTimerAdapter.Start();
    }
    public void StopSimulation()
    {
        _dispatcherTimerAdapter.Stop();
    }
    public void SimulationOneStep()
    {
        DispatcherTimer_Tick();
    }
    public void SetDispatcherTimerInterval(double timerInterval)
    {
        _dispatcherTimerAdapter.DispatcherTimerInterval = timerInterval;
    }
    private void DispatcherTimer_Tick()
    {
        _gameLogic.SimulationStep();
        _gameLogic.UpdateAliveCellsCount();
        // SendMessageToUI();
    }

    internal ObservableCollection<List<Cell>> SetupBoardArray(int cellsArraySize, int cellSize) =>
        _gameLogic.SetupBoardArray(cellsArraySize, cellSize);

    internal void ResetBoard() =>
        _gameLogic.ResetBoard();

    //public void MouseEvent(MouseEventArgs e)
    //{
    //    Rectangle ClickedRectangle = e.OriginalSource as Rectangle;
    //    Cell cell = ClickedRectangle.DataContext as Cell;

    //    if (e.LeftButton == MouseButtonState.Pressed)
    //    {
    //        ClickedRectangle.Fill = Brushes.Green;
    //        cell.isAlive = true;
    //    }
    //    else
    //    {
    //        ClickedRectangle.Fill = Brushes.White;
    //        cell.isAlive = false;
    //    }
    //    UpdateAliveCellsCount();
    //    SendMessageToUI();
    //}
}
