using UnityEngine;

namespace Infrastructure.AssetManagement.ConcreteAssets
{
    public class UIRootAsset :  Asset<GameObject>
    {
        private const string Path = "UI/UIRoot";
        public UIRootAsset(IAssetsDatabase database) : base(database, Path) {}
    }
}