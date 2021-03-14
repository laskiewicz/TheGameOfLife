using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TheGameOfLifeLibrary;
using TheGameOfLifeLibrary.Models;
using WinUITheGameOfLife.Messages;
using WinUITheGameOfLife.Views;

namespace WinUITheGameOfLife.ViewModels
{
    public class BoardViewModel : ObservableObject
    {
        private bool _startButtonIsEnabled = true;
        private int _aliveCellsCount;
        private int _generation;
        private const int CellsArraySize = 50;
        private const int CellSize = 10;
        private double _simulationSpeed = 250;
        private string _currentVersion;
        private readonly GameLogic _gameLogic;

        public ObservableCollection<List<Cell>> CellItems { get; set; }
        public RelayCommand StartSimulationCommand { get; private set; }
        public RelayCommand StopSimulationCommand { get; private set; }
        public RelayCommand ResetBoardCommand { get; private set; }
        public RelayCommand SimulationStepCommand { get; private set; }
        public RelayCommand GoToHelpCommand { get; private set; }

        public int AliveCellsCount
        {
            get => _aliveCellsCount;
            set => SetProperty(ref _aliveCellsCount, value);
        }
        public int Generation
        {
            get => _generation;
            set => SetProperty(ref _generation, value);
        }

        public string CurrentVersion
        {
            get
            {
                try
                {
                    return GetType().Assembly.GetName().Version.ToString();
                }
                catch
                {
                    _currentVersion = "Debug";
                }
                return _currentVersion;
            }
        }

        public double SimulationSpeed
        {
            get => _simulationSpeed;
            set
            {
                SetProperty(ref _simulationSpeed, value);
                _gameLogic.SetDispatcherTimerInterval(_simulationSpeed);
            }
        }
        public bool StartButtonIsEnabled
        {
            get => _startButtonIsEnabled;
            set
            {
                SetProperty(ref _startButtonIsEnabled, value);
                OnPropertyChanged(nameof(StopButtonIsEnabled));
                StartSimulationCommand.NotifyCanExecuteChanged();
                StopSimulationCommand.NotifyCanExecuteChanged();
            }
        }
        public bool StopButtonIsEnabled => !StartButtonIsEnabled;

        public BoardViewModel(GameLogic gameLogic)
        {
            _gameLogic = gameLogic;
            WeakReferenceMessenger.Default.Register<StateOfBoardChangedMessage>(this, (r, m) => GetGameLogicEvent(m));
            StartSimulationCommand = new RelayCommand(StartSimulation, () => StartButtonIsEnabled);
            StopSimulationCommand = new RelayCommand(StopSimulation, () => StopButtonIsEnabled);
            ResetBoardCommand = new RelayCommand(ResetBoard);
            SimulationStepCommand = new RelayCommand(SimulationOneStep);
            GoToHelpCommand = new RelayCommand(GoToHelp);

            _gameLogic.SetDispatcherTimerInterval(_simulationSpeed);
            CellItems = gameLogic.DrawBoard(CellsArraySize, CellSize);
        }

        private void GetGameLogicEvent(StateOfBoardChangedMessage param)
        {
            Generation = param.Value.Generation;
            AliveCellsCount = param.Value.AliveCellsCount;
        }
        private void StartSimulation()
        {
            StartButtonIsEnabled = false;
            _gameLogic.StartSimulation();
        }
        private void StopSimulation()
        {
            StartButtonIsEnabled = true;
            _gameLogic.StopSimulation();
        }
        private void SimulationOneStep()
        {
            _gameLogic.SimulationOneStep();
        }
        private void ResetBoard()
        {
            StopSimulation();
            _gameLogic.ResetBoard();
        }
        private void GoToHelp()
        {
            ShellView shell = Ioc.Default.GetService<ShellView>();
            shell.GetNavigationFrame().Navigate(typeof(HelpView));
        }
        //public void CellMouseEvents(object sender, MouseEventArgs e)
        //{
        //    if (e.LeftButton == MouseButtonState.Pressed || e.RightButton == MouseButtonState.Pressed)
        //    {
        //        _gameLogic.MouseEvent(e);
        //    }
        //}
    }
}
