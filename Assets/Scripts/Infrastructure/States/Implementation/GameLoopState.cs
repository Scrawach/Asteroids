using Components;
using Infrastructure.States.Abstract;
using UnityEngine;

namespace Infrastructure.States.Implementation
{
    public class GameLoopState : IPayloadState<GameObject>
    {
        public GameLoopState()
        {

        }
        
        public void Enter(IStateMachine stateMachine, GameObject player)
        {
            
        }
        
        public void Exit()
        {
            
        }
    }
}