﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFTheGameOfLife.Events;
using WPFTheGameOfLife.GameOfLife;
using WPFTheGameOfLife.Models;

namespace WPFTheGameOfLife.ViewModels
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
        public ICommand StartSimulationCommand { get; private set; }
        public ICommand StopSimulationCommand { get; private set; }
        public ICommand ResetBoardCommand { get; private set; }
        public ICommand SimulationStepCommand { get; private set; }
        public ICommand GoToHelpCommand { get; private set; }

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
            }
        }
        public bool StopButtonIsEnabled => !_startButtonIsEnabled;

        public BoardViewModel(GameLogic gameLogic) //, IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _gameLogic = gameLogic;
            // _regionManager = regionManager;
            // eventAggregator.GetEvent<StateOfBoardChangedEvent>().Subscribe(GetGameLogicEvent);
            StartSimulationCommand = new RelayCommand(StartSimulation, () => StartButtonIsEnabled);
            StopSimulationCommand = new RelayCommand(StopSimulation, () => StopButtonIsEnabled);
            ResetBoardCommand = new RelayCommand(ResetBoard);
            SimulationStepCommand = new RelayCommand(SimulationOneStep);
            GoToHelpCommand = new RelayCommand(GoToHelp);

            _gameLogic.SetDispatcherTimerInterval(_simulationSpeed);
            CellItems = gameLogic.DrawBoard(CellsArraySize, CellSize);
        }

        private void GetGameLogicEvent(GameLogicEventParameter param)
        {
            Generation = param.Generation;
            AliveCellsCount = param.AliveCellsCount;
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
            // _regionManager.RequestNavigate("BoardRegion", "SplashView");
        }
        public void CellMouseEvents(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed || e.RightButton == MouseButtonState.Pressed)
            {
                _gameLogic.MouseEvent(e);
            }
        }
    }
}
