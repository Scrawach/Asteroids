using System;
using Components.Data;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Health))]
    public class Death : MonoBehaviour
    {
        private Health _health;
        
        public event Action<Death> Happened;

        private void Awake() => 
            _health = GetComponent<Health>();

        private void OnEnable() => 
            _health.Changed += OnHealthChanged;

        private void OnDisable() => 
            _health.Changed -= OnHealthChanged;

        private void OnHealthChanged(object sender, HealthArgs args)
        {
            if (args.Current <= 0)
                Happened?.Invoke(this);
        }
    }
}