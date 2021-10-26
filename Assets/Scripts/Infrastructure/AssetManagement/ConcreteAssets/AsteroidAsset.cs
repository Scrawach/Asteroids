using UnityEngine;

namespace Infrastructure.AssetManagement.ConcreteAssets
{
    public class AsteroidAsset : Asset<GameObject>
    {
        private const string Path = "Environment/Asteroid";
        public AsteroidAsset(IAssetsDatabase database) : base(database, Path) {}
    }
}