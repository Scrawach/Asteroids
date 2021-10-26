using UnityEngine;

namespace Infrastructure.AssetManagement.ConcreteAssets
{
    public class VfxDeathAsset :  Asset<GameObject>
    {
        private const string Path = "VFX/PlayerDeath_VFX";
        public VfxDeathAsset(IAssetsDatabase database) : base(database, Path) {}
    }
}