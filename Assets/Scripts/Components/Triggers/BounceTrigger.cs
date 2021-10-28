using Components.Environment;
using Extensions;
using UnityEngine;

namespace Components.Triggers
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
            
            if (other.TryGetComponent(out EndlessMovement endlessMovement))
                _movement.Construct(endlessMovement.Direction);
            else
                _movement.Inverse();
        }
        
        private bool IsNotAvailableLayer(Component other) => 
            _targetMask.Contains(other.gameObject.layer) == false;
    }
}