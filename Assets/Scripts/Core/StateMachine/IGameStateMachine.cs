namespace Core.StateMachine
{
    public interface IGameStateMachine
    {
        void ChangeState<T>() where T : IState;
    }
}