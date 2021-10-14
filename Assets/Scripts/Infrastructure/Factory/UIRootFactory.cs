using System;
using Infrastructure.AssetManagement;
using Infrastructure.Factory.Abstract;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Factory
{
    public class UIRootFactory : IObjectFactory
    {
        private const string RootPath = "UI/Root";
        private readonly IAssets _assets;

        public UIRootFactory(IAssets assets) => 
            _assets = assets;

        public GameObject Create() => 
            _assets.Instantiate<GameObject>(RootPath);
    }
}