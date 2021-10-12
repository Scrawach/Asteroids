using System;
using Components.Abstract;
using Components.Data;
using UnityEngine;

namespace Components
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] 
        private int _current;
        
        [SerializeField] 
        private int _max;

        public event EventHandler<HealthArgs> Changed;

        public void Apply(Damage damage)
        {
            _current -= damage;
            Changed?.Invoke(this, new HealthArgs(_current, _max));
        }
    }
}