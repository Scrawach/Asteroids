using Infrastructure.AssetManagement;
using UnityEngine;

namespace Infrastructure.Factory.Abstract
{
    public class ObjectFactory : IObjectFactory
    {
        private readonly IAsset _asset;

        public ObjectFactory(IAsset asset) => 
            _asset = asset;
        
        public GameObject Create() => 
            _asset.Instantiate<GameObject>();
    }
}