using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace WPFTheGameOfLife.Messages
{
    public class StateOfBoardChangedMessage : ValueChangedMessage<GameLogicMessageParameter>
    {
        public StateOfBoardChangedMessage(GameLogicMessageParameter eventParameter) : base(eventParameter) { }
    }
    public class GameLogicMessageParameter
    {
        public int AliveCellsCount { get; set; }
        public int Generation { get; set; }
    }
}
