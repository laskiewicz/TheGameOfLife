
namespace WPFTheGameOfLife.Events
{
    public class StateOfBoardChangedEvent { }//: PubSubEvent<GameLogicEventParameter> { }
    public class GameLogicEventParameter
    {
        public int AliveCellsCount { get; set; }
        public int Generation { get; set; }
    }
}
