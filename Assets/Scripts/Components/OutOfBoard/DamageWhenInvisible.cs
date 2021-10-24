using Components.Abstract;
using Components.Data;
using UnityEngine;

namespace Components.OutOfBoard
{
    [RequireComponent(typeof(IDamageable))]
    public class DamageWhenInvisible : InvisibleObserver
    {
        private IDamageable _damageable;

        private void Awake() => 
            _damageable = GetComponent<IDamageable>();

        protected override void OnBecameInvisibleSafe() => 
            _damageable.Apply(new Damage(10));
    }
}