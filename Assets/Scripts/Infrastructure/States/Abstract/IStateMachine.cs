namespace Infrastructure.States.Abstract
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : IDefaultState;
        void Enter<TState, TPayload>(TPayload payload) where TState : IPayloadState<TPayload>;
    }
}