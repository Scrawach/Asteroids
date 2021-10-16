using Components.Abstract;
using Components.Data;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Collider2D))]
    public class DamageTrigger : MonoBehaviour
    {
        [SerializeField] 
        private int _value;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
                damageable.Apply(new Damage(_value));
        }
    }
}