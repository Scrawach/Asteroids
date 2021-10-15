using System;
using Components.Abstract;
using Components.Data;
using UnityEngine;

namespace Components.Player
{
    [RequireComponent(typeof(IDamageable))]
    public class BoardDamage : MonoBehaviour
    {
        [SerializeField] 
        private int _value;
        
        private IDamageable _damageable;
        private bool _isInvisible;

        private void Awake() => 
            _damageable = GetComponent<IDamageable>();

        private void Update()
        {
            if (_isInvisible)
            {
                _damageable.Apply(new Damage(10000));
                enabled = false;
            }
        }

        private void OnBecameInvisible() => 
            _isInvisible = true;
    }
}