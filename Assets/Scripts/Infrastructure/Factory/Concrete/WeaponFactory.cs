using Components;
using Components.Player;
using Infrastructure.AssetManagement;
using Infrastructure.Factory.Abstract;
using Infrastructure.StaticData;
using StaticData;
using UnityEngine;

namespace Infrastructure.Factory.Concrete
{
    public class WeaponFactory : IObjectFactory
    {
        private readonly IObjectFactory _objectFactory;
        private readonly BulletFactory _bulletFactory;
        private readonly IAsset<WeaponConfig> _config;

        public WeaponFactory(IObjectFactory objectFactory, BulletFactory bulletFactory, IAsset<WeaponConfig> config)
        {
            _objectFactory = objectFactory;
            _bulletFactory = bulletFactory;
            _config = config;
        }
        
        public GameObject Create()
        {
            var obj = _objectFactory.Create();
            var data = _config.Load();
            obj.GetComponent<Weapon>().Construct(_bulletFactory, data.Cooldown);
            return obj;
        }
    }
}