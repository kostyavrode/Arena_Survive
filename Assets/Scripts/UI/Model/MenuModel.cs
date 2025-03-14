using Core.StateMachine;

namespace UI.Model
{
    public class MenuModel
    {
        private readonly IGameStateMachine _gameStateMachine;

        public MenuModel(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void StartGame()
        {
            _gameStateMachine.ChangeState<PlayingState>();
        }
    }
}