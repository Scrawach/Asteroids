using Components.Abstract;
using Components.Common;
using Infrastructure.Factory.Concrete;
using UnityEngine;

namespace Components.Player
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] 
        private Transform _shootPoint;

        private BulletFactory _bullets;
        private MonoTimer _cooldown;

        public void Construct(BulletFactory bullets, float cooldown)
        {
            _bullets = bullets;
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
            _bullets.Create(_shootPoint.position, _shootPoint.right);
            _cooldown.Start();
            return true;
        }
    }
}