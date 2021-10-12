using Infrastructure.States.Abstract;
using Infrastructure.States.Implementation;

namespace Infrastructure
{
    public class Game
    {
        private readonly IStateMachine _stateMachine;

        public Game(IStateMachine stateMachine) => 
            _stateMachine = stateMachine;
        
        public void Run() => 
            _stateMachine.Enter<BootstrapState>();
    }
}