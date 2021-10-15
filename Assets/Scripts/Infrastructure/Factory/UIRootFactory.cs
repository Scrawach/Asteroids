using Infrastructure.AssetManagement;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class UIRootFactory : IObjectFactory
    {
        private const string RootPath = "UI/UIRoot";
        private readonly IAssets _assets;

        public UIRootFactory(IAssets assets) => 
            _assets = assets;

        public GameObject Create() => 
            _assets.Instantiate<GameObject>(RootPath);
    }
}