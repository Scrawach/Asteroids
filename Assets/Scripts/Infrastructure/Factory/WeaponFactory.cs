using Components;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class WeaponFactory : IObjectFactory
    {
        private readonly IObjectFactory _objectFactory;
        private readonly IObjectFactory _bulletFactory;

        public WeaponFactory(IObjectFactory objectFactory, IObjectFactory bulletFactory)
        {
            _objectFactory = objectFactory;
            _bulletFactory = bulletFactory;
        }
        
        public GameObject Create()
        {
            var obj = _objectFactory.Create();
            obj.GetComponent<Weapon>().Construct(_bulletFactory, 2f);
            return obj;
        }
    }
}