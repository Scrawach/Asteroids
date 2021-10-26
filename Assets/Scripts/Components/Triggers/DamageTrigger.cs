using Components.Abstract;
using Components.Data;
using Extensions;
using UnityEngine;

namespace Components.Triggers
{
    [RequireComponent(typeof(Collider2D))]
    public class DamageTrigger : MonoBehaviour
    {
        [SerializeField] 
        private int _value;

        [SerializeField] 
        private LayerMask _targetMask;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsNotAvailableLayer(other))
                return;
            
            if (other.TryGetComponent(out IDamageable damageable))
                damageable.Apply(new Damage(_value));
        }

        private bool IsNotAvailableLayer(Component other) => 
            _targetMask.Contains(other.gameObject.layer) == false;
    }
}