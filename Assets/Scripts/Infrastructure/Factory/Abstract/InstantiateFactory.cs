using Infrastructure.AssetManagement;
using UnityEngine;

namespace Infrastructure.Factory.Abstract
{
    public class InstantiateFactory : IObjectFactory
    {
        private readonly IAsset _asset;

        public InstantiateFactory(IAsset asset) => 
            _asset = asset;
        
        public GameObject Create() => 
            _asset.Instantiate<GameObject>();
    }
}