namespace Infrastructure.AssetManagement.ConcreteAssets
{
    public class PlayerBulletAsset : Asset
    {
        private const string Path = "Weapon/Bullet";
        public PlayerBulletAsset(IAssetsDatabase database) : base(database, Path) {}
    }
}