namespace Infrastructure.AssetManagement.ConcreteAssets
{
    public class PlayerAsset : Asset
    {
        private const string Path = "Player/PlayerShip";
        public PlayerAsset(IAssetsDatabase database) : base(database, Path) {}
    }
}