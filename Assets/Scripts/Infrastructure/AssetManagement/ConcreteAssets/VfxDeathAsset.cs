namespace Infrastructure.AssetManagement.ConcreteAssets
{
    public class VfxDeathAsset : Asset
    {
        private const string Path = "VFX/PlayerDeath_VFX";
        public VfxDeathAsset(IAssetsDatabase database) : base(database, Path) {}
    }
}