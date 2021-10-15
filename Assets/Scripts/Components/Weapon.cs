using System;
using System.Collections;
using Components.Abstract;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Components
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] 
        private Transform _shotPoint;

        private IObjectFactory _buttonFactory;
        private MonoTimer _cooldown;

        public void Construct(IObjectFactory bullets, float cooldown)
        {
            _buttonFactory = bullets;
            _cooldown = new MonoTimer(cooldown);
        }

        private void FixedUpdate() => 
            _cooldown.Update(Time.fixedDeltaTime);

        public bool TryFire() => 
            CanShot() && Fire();

        private bool CanShot() => 
            _cooldown.IsDone;

        private bool Fire()
        {
            var bullet = _buttonFactory.Create();
            bullet.transform.position = _shotPoint.position;
            _cooldown.Start();
            return true;
        }
    }
}