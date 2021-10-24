using Components;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class WeaponFactory : IObjectFactory
    {
        private readonly IObjectFactory _objectFactory;
        private readonly BulletFactory _bulletFactory;

        public WeaponFactory(IObjectFactory objectFactory, BulletFactory bulletFactory)
        {
            _objectFactory = objectFactory;
            _bulletFactory = bulletFactory;
        }
        
        public GameObject Create()
        {
            var obj = _objectFactory.Create();
            obj.GetComponent<Weapon>().Construct(_bulletFactory, .1f);
            return obj;
        }
    }
}