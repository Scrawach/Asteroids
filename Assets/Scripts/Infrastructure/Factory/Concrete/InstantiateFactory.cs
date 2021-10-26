using Infrastructure.AssetManagement;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory.Concrete
{
    public class InstantiateFactory : IObjectFactory
    {
        private readonly IAsset<GameObject> _asset;

        public InstantiateFactory(IAsset<GameObject> asset) => 
            _asset = asset;
        
        public GameObject Create() => 
            Object.Instantiate(_asset.Load());
    }
}