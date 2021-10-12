namespace Infrastructure.States.Abstract
{
    public interface IDefaultState : IState
    {
        void Enter(IStateMachine stateMachine);
    }
}