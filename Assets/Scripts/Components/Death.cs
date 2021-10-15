using System;
using Components.Data;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Health))]
    public class Death : MonoBehaviour
    {
        private Health _health;
        private IObjectFactory _vfxFactory;
        
        public event Action<Death> Happened;

        public void Construct(IObjectFactory vfxFactory) => 
            _vfxFactory = vfxFactory;

        private void Awake() => 
            _health = GetComponent<Health>();

        private void OnEnable() => 
            _health.Changed += OnHealthChanged;

        private void OnDisable() => 
            _health.Changed -= OnHealthChanged;

        private void OnHealthChanged(object sender, HealthArgs args)
        {
            if (args.Current <= 0)
            {
                var vfx = _vfxFactory.Create();
                vfx.transform.position = transform.position;
                Happened?.Invoke(this);
            }
        }
    }
}