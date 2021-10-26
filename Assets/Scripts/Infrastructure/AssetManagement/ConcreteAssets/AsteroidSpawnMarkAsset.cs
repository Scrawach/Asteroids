using UnityEngine;

namespace Infrastructure.AssetManagement.ConcreteAssets
{
    public class AsteroidSpawnMarkAsset : Asset<GameObject>
    {
        private const string Path = "Environment/AsteroidSpawn";
        public AsteroidSpawnMarkAsset(IAssetsDatabase database) : base(database, Path) {}
    }
}