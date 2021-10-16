using System;
using Components.Abstract;
using Infrastructure.InputLogic;
using UnityEngine;

namespace Components.Player
{
    [RequireComponent(typeof(IMover))]
    public class PlayerMove : MonoBehaviour
    {
        private IPlayerInput _playerInput;
        private IMover _mover;
        
        public void Construct(IPlayerInput playerInput) => 
            _playerInput = playerInput;

        private void Awake() => 
            _mover = GetComponent<IMover>();

        private void FixedUpdate() => 
            _mover.Move(to: _playerInput.Axis);
    }
}