namespace Infrastructure.AssetManagement.ConcreteAssets
{
    public class AsteroidSpawnMarkAsset : Asset
    {
        private const string Path = "Environment/AsteroidSpawn";
        public AsteroidSpawnMarkAsset(IAssetsDatabase database) : base(database, Path) {}
    }
}