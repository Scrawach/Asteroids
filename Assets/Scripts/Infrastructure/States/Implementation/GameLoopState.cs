using Components;
using Infrastructure.States.Abstract;
using UnityEngine;

namespace Infrastructure.States.Implementation
{
    public class GameLoopState : IPayloadState<GameObject>
    {
        private IStateMachine _stateMachine;
        private GameObject _player;
        
        public GameLoopState()
        {

        }
        
        public void Enter(IStateMachine stateMachine, GameObject player)
        {
            _stateMachine = stateMachine;
            if (player.TryGetComponent(out Death death))
                death.Happened += OnPlayerDied;
        }

        private void OnPlayerDied(Death death)
        {
            death.Happened -= OnPlayerDied;
            _stateMachine.Enter<BootstrapState>();
        }

        public void Exit()
        {
            
        }
    }
}