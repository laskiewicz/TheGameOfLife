using System;
using Xunit;
using WPFTheGameOfLife.GameOfLife;
using Prism.Events;
using WPFTheGameOfLife.Events;

namespace TheGameOfLife.Tests
{
    public class GameLogicTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(1000)]
        [InlineData(int.MaxValue)]
        public void SetDispatcherTimerInterval_ShouldSet(double timerInterval)
        {
            DispatcherTimerAdapter dsa = new DispatcherTimerAdapter();
            GameLogic gl = new GameLogic(null, dsa);

            gl.SetDispatcherTimerInterval(timerInterval);

            Assert.Equal(timerInterval, dsa.DispatcherTimerInterval);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(-1000)]
        public void SetDispatcherTimerInterval_ShouldFail(double timerInterval)
        {
            DispatcherTimerAdapter dsa = new DispatcherTimerAdapter();
            GameLogic gl = new GameLogic(null, dsa);

            Assert.Throws<ArgumentOutOfRangeException>(() => gl.SetDispatcherTimerInterval(timerInterval));
        }
        [Theory]
        [InlineData(0, 0)]
        [InlineData(100, 100)]
        public void DrawBoard_ShouldPass(int cellCount, int cellSize)
        {
            GameLogic gl = new GameLogic(null, null);

            gl.DrawBoard(cellCount, cellSize);

            Assert.Equal(cellCount, gl.CellItems.Count);
            foreach (var subCells in gl.CellItems)
            {
                foreach (var cell in subCells)
                {
                    Assert.Equal(cellSize, cell.Height);
                    Assert.Equal(cellSize, cell.Width);
                }
            }
        }
        [Fact]
        public void ResetBoard_ShouldPass()
        {
            GameLogic gl = new GameLogic(null, null);
            gl.DrawBoard(10, 10);
            foreach (var subCells in gl.CellItems)
            {
                foreach (var cell in subCells)
                {
                    cell.isAlive = true;
                }
            }

            gl.ResetBoard();

            foreach (var subCells in gl.CellItems)
            {
                foreach (var cell in subCells)
                {
                    Assert.False(cell.isAlive);
                }
            }
        }
        [Fact]
        public void SimulationStep_ShouldPassSimpleCase()
        {
            DispatcherTimerDeterministic dtd = new DispatcherTimerDeterministic();
            GameLogic gl = new GameLogic(null, dtd);
            gl.DrawBoard(10, 10);
            gl.CellItems[0][1].isAlive = true;
            gl.CellItems[1][1].isAlive = true;
            gl.CellItems[2][1].isAlive = true;

            gl.StartSimulation();

            Assert.True(gl.CellItems[1][0].isAlive);
            Assert.True(gl.CellItems[1][1].isAlive);
            Assert.True(gl.CellItems[1][2].isAlive);
        }
        [Fact]
        public void SimulationStep_ShouldPassTwoIterations()
        {
            DispatcherTimerDeterministic dtd = new DispatcherTimerDeterministic();
            GameLogic gl = new GameLogic(null, dtd);
            gl.DrawBoard(10, 10);
            gl.CellItems[0][1].isAlive = true;
            gl.CellItems[1][1].isAlive = true;
            gl.CellItems[2][1].isAlive = true;

            dtd.Iterations = 2;
            gl.StartSimulation();

            Assert.True(gl.CellItems[0][1].isAlive);
            Assert.True(gl.CellItems[1][1].isAlive);
            Assert.True(gl.CellItems[2][1].isAlive);
        }
        [Fact]
        public void SimulationStep_ShouldPassRectanglePattern()
        {
            DispatcherTimerDeterministic dtd = new DispatcherTimerDeterministic();
            GameLogic gl = new GameLogic(null, dtd);
            gl.DrawBoard(10, 10);
            gl.CellItems[1][2].isAlive = true;
            gl.CellItems[2][2].isAlive = true;
            gl.CellItems[3][2].isAlive = true;
            gl.CellItems[4][2].isAlive = true;

            gl.StartSimulation();

            Assert.True(gl.CellItems[2][1].isAlive);
            Assert.True(gl.CellItems[2][2].isAlive);
            Assert.True(gl.CellItems[2][3].isAlive);
            Assert.True(gl.CellItems[3][1].isAlive);
            Assert.True(gl.CellItems[3][2].isAlive);
            Assert.True(gl.CellItems[3][3].isAlive);
        }
        [Fact]
        public void AliveCellsCount_ShouldPassRectanglePattern()
        {
            DispatcherTimerDeterministic dtd = new DispatcherTimerDeterministic();
            EventAggregator ea = new EventAggregator();
            int expectedAliveCellsCount = 6;
            int aliveCellsCount = 0;
            ea.GetEvent<StateOfBoardChangedEvent>().Subscribe((param) => aliveCellsCount = param.AliveCellsCount);

            GameLogic gl = new GameLogic(ea, dtd);
            gl.DrawBoard(10, 10);
            gl.CellItems[1][2].isAlive = true;
            gl.CellItems[2][2].isAlive = true;
            gl.CellItems[3][2].isAlive = true;
            gl.CellItems[4][2].isAlive = true;

            gl.StartSimulation();

            Assert.Equal(expectedAliveCellsCount, aliveCellsCount);
        }
        [Fact]
        public void SimulationStep_ShouldPassRectanglePatternTwoIterations()
        {
            DispatcherTimerDeterministic dtd = new DispatcherTimerDeterministic();
            GameLogic gl = new GameLogic(null, dtd);
            gl.DrawBoard(10, 10);
            gl.CellItems[1][2].isAlive = true;
            gl.CellItems[2][2].isAlive = true;
            gl.CellItems[3][2].isAlive = true;
            gl.CellItems[4][2].isAlive = true;

            dtd.Iterations = 2;
            gl.StartSimulation();

            Assert.True(gl.CellItems[1][2].isAlive);
            Assert.True(gl.CellItems[2][1].isAlive);
            Assert.True(gl.CellItems[2][3].isAlive);
            Assert.True(gl.CellItems[3][1].isAlive);
            Assert.True(gl.CellItems[3][3].isAlive);
            Assert.True(gl.CellItems[4][2].isAlive);
        }
    }
}
