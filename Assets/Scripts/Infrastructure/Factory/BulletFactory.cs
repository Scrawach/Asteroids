using Infrastructure.AssetManagement;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class BulletFactory : IObjectFactory
    {
        private readonly IAsset _asset;

        public BulletFactory(IAsset asset) => 
            _asset = asset;

        public GameObject Create() => 
            _asset.Instantiate<GameObject>();
    }
}