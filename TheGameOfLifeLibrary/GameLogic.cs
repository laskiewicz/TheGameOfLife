using TheGameOfLifeLibrary.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TheGameOfLifeLibrary
{
    public class GameLogic
    {
        private int _aliveCellsCount;
        private int _generation;
        private IDispatcherTimerAdapter _dispatcherTimerAdapter;
        public ObservableCollection<List<Cell>> CellItems;

        public GameLogic(IDispatcherTimerAdapter dispatcherTimerAdapter)
        {
            _dispatcherTimerAdapter = dispatcherTimerAdapter;
            _dispatcherTimerAdapter?.SetTask(DispatcherTimer_Tick);
        }

        public void StartSimulation()
        {
            _dispatcherTimerAdapter.Start();
        }
        public void StopSimulation()
        {
            _dispatcherTimerAdapter.Stop();
        }
        public void SetDispatcherTimerInterval(double timerInterval)
        {
            _dispatcherTimerAdapter.DispatcherTimerInterval = timerInterval;
        }
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
        public ObservableCollection<List<Cell>> DrawBoard(int cllsArraySize, int cellSize)
        {
            CellItems = new ObservableCollection<List<Cell>>();

            for (int i = 0; i < cllsArraySize; i++)
            {
                CellItems.Add(new List<Cell>());

                for (int j = 0; j < cllsArraySize; j++)
                {
                    Cell cell = new Cell()
                    {
                        X = i * cellSize,
                        Y = j * cellSize,
                        Width = cellSize,
                        Height = cellSize,
                        //Stroke = Brushes.LightGray,
                        //Fill = Brushes.White,
                        isAlive = false,
                    };
                    CellItems[i].Add(cell);
                }
            }
            return CellItems;
        }
        public void ResetBoard()
        {
            foreach (var subCells in CellItems)
            {
                foreach (var cell in subCells)
                {
                    cell.isAlive = false; // kill all cells
                    //cell.Fill = Brushes.White;
                }
            }
            _generation = 0;
            // SendMessageToUI();
        }

        public void SimulationOneStep()
        {
            DispatcherTimer_Tick();
        }

        private void DispatcherTimer_Tick()
        {
            _generation++;
            SimulationStep();
            UpdateAliveCellsCount();
            // SendMessageToUI();
        }
        private void SimulationStep()
        {
            // Checking for neighbours
            for (int i = 0; i < CellItems.Count; i++)
            {
                for (int j = 0; j < CellItems[i].Count; j++)
                {
                    int neighbours = 0;
                    for (int x = i - 1; x <= i + 1; x++)
                    {
                        for (int y = j - 1; y <= j + 1; y++)
                        {
                            if (x == i && y == j)
                                continue;
                            // Wraping around array and adding neighbour if cell is alive
                            neighbours += CellItems
                                [(x + CellItems.Count) % CellItems.Count]
                                [(y + CellItems[i].Count) % CellItems[i].Count]
                                .isAlive ? 1 : 0;
                        }
                    }
                    // Rules in game of life, checking if cell will be alive in next generation
                    if (!CellItems[i][j].isAlive && neighbours == 3)
                        CellItems[i][j].willBeAlive = true;
                    else if (CellItems[i][j].isAlive && (neighbours == 3 || neighbours == 2))
                        CellItems[i][j].willBeAlive = true;
                    else
                        CellItems[i][j].willBeAlive = false;
                }
            }
            // Next life cycle
            foreach (var subCells in CellItems)
            {
                foreach (var cell in subCells)
                {
                    bool oldWillBeAlive = cell.willBeAlive;
                    bool oldIsAlive = cell.isAlive;
                    cell.isAlive = cell.willBeAlive;

                    //if (!oldWillBeAlive && oldIsAlive)
                    //    //cell.Fill = Brushes.Red;
                    //else
                    //    //cell.Fill = (cell.isAlive) ? Brushes.Green : Brushes.White;
                }
            }
        }
        private void UpdateAliveCellsCount()
        {
            _aliveCellsCount = 0;
            foreach (var subCells in CellItems)
            {
                foreach (var cell in subCells)
                {
                    if (cell.isAlive)
                        _aliveCellsCount++;
                }
            }
        }
        //private void SendMessageToUI()
        //{
        //    WeakReferenceMessenger.Default.Send(
        //        new StateOfBoardChangedMessage(
        //            new GameLogicMessageParameter()
        //            {
        //                AliveCellsCount = _aliveCellsCount,
        //                Generation = _generation
        //            }));
        //}
    }
}
