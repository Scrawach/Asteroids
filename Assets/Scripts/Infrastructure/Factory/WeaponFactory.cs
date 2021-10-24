using Components;
using Infrastructure.Factory.Abstract;
using Infrastructure.StaticData;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class WeaponFactory : IObjectFactory
    {
        private readonly IObjectFactory _objectFactory;
        private readonly BulletFactory _bulletFactory;
        private readonly IStaticDatabase _staticDatabase;

        public WeaponFactory(IObjectFactory objectFactory, BulletFactory bulletFactory, IStaticDatabase staticDatabase)
        {
            _objectFactory = objectFactory;
            _bulletFactory = bulletFactory;
            _staticDatabase = staticDatabase;
        }
        
        public GameObject Create()
        {
            var obj = _objectFactory.Create();
            var cooldown = _staticDatabase.ForWeapon().Cooldown;
            obj.GetComponent<Weapon>().Construct(_bulletFactory, cooldown);
            return obj;
        }
    }
}