using System;
using Extensions;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(EndlessMovement))]
    [RequireComponent(typeof(Collider2D))]
    public class BounceTrigger : MonoBehaviour
    {
        [SerializeField] 
        private LayerMask _targetMask;
        
        private EndlessMovement _movement;

        private void Awake() => 
            _movement = GetComponent<EndlessMovement>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsNotAvailableLayer(other))
                return;
            _movement.Inverse();
        }
        
        private bool IsNotAvailableLayer(Component other) => 
            _targetMask.Contains(other.gameObject.layer) == false;
    }
}