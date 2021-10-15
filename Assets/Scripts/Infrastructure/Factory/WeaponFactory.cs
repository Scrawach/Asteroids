using Components;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class WeaponFactory : IObjectFactory
    {
        private readonly IObjectFactory _factory;
        private readonly IObjectFactory _bulletFactory;

        public WeaponFactory(IObjectFactory factory, IObjectFactory bulletFactory)
        {
            _factory = factory;
            _bulletFactory = bulletFactory;
        }
        
        public GameObject Create()
        {
            var obj = _factory.Create();
            obj.GetComponent<Weapon>().Construct(_bulletFactory, 2f);
            return obj;
        }
    }
}