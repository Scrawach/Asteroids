using Infrastructure.AssetManagement;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class UIRootFactory : IObjectFactory
    {
        private const string RootPath = "UI/UIRoot";
        private readonly IAsset _asset;

        public UIRootFactory(IAsset asset) => 
            _asset = asset;

        public GameObject Create() => 
            _asset.Instantiate<GameObject>();
    }
}