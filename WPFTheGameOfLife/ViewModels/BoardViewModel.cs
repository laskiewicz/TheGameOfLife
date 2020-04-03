using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Deployment.Application;
using System.Windows.Input;
using WPFTheGameOfLife.Events;
using WPFTheGameOfLife.GameOfLife;
using WPFTheGameOfLife.Models;

namespace WPFTheGameOfLife.ViewModels
{
    public class BoardViewModel : BindableBase
    {
        private bool _startButtonIsEnabled = true;
        private int _aliveCellsCount;
        private int _generation;
        private const int CellsArraySize = 50;
        private const int CellSize = 10;
        private double _simulationSpeed = 250;
        private string _currentVersion;
        private GameLogic _gameLogic;
        private readonly IRegionManager _regionManager;

        public ObservableCollection<List<Cell>> CellItems { get; set; }
        public DelegateCommand StartSimulationCommand { get; private set; }
        public DelegateCommand StopSimulationCommand { get; private set; }
        public DelegateCommand ResetBoardCommand { get; private set; }
        public DelegateCommand SimulationStepCommand { get; private set; }
        public DelegateCommand GoToHelpCommand { get; private set; }

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
                    _currentVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
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
                RaisePropertyChanged("StopButtonIsEnabled");
            }
        }
        public bool StopButtonIsEnabled => !_startButtonIsEnabled;

        public BoardViewModel(GameLogic gameLogic, IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _gameLogic = gameLogic;
            _regionManager = regionManager;
            eventAggregator.GetEvent<StateOfBoardChangedEvent>().Subscribe(GetGameLogicEvent);
            StartSimulationCommand = new DelegateCommand(StartSimulation).ObservesCanExecute(() => StartButtonIsEnabled);
            StopSimulationCommand = new DelegateCommand(StopSimulation).ObservesCanExecute(() => StopButtonIsEnabled);
            ResetBoardCommand = new DelegateCommand(ResetBoard);
            SimulationStepCommand = new DelegateCommand(SimulationOneStep);
            GoToHelpCommand = new DelegateCommand(GoToHelp);

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
            _regionManager.RequestNavigate("BoardRegion", "SplashView");
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
