using System;
using Components.Abstract;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(IMover))]
    public class EndlessMovement : MonoBehaviour
    {
        private IMover _mover;
        private Vector2 _direction;

        public void Construct(Vector2 direction) => 
            _direction = direction;

        private void Awake() => 
            _mover = GetComponent<IMover>();

        private void Update() => 
            _mover.Move(_direction);
    }
}