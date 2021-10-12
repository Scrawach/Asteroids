using System;
using Components.Abstract;
using InputLogic;
using UnityEngine;

namespace Components.Player
{
    [RequireComponent(typeof(IEngine))]
    public class PlayerMove : MonoBehaviour
    {
        private IPlayerInput _playerInput;
        private IEngine _engine;
        
        public void Construct(IPlayerInput playerInput) => 
            _playerInput = playerInput;

        private void Awake() => 
            _engine = GetComponent<IEngine>();

        private void FixedUpdate() => 
            _engine.Move(to: _playerInput.Axis);
    }
}