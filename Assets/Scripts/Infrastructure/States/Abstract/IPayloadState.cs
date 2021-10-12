namespace Infrastructure.States.Abstract
{
    public interface IPayloadState<in TPayload> : IState
    {
        void Enter(IStateMachine stateMachine, TPayload payload);
    }
}