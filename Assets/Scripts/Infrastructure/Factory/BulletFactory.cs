using Infrastructure.AssetManagement;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class BulletFactory : IObjectFactory
    {
        private const string RootPath = "Weapon/Bullet";
        private readonly IAssets _assets;

        public BulletFactory(IAssets assets) => 
            _assets = assets;

        public GameObject Create() => 
            _assets.Instantiate<GameObject>(RootPath);
    }
}