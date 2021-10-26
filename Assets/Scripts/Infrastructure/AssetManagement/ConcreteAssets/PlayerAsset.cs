using UnityEngine;

namespace Infrastructure.AssetManagement.ConcreteAssets
{
    public class PlayerAsset :  Asset<GameObject>
    {
        private const string Path = "Player/PlayerShip";
        public PlayerAsset(IAssetsDatabase database) : base(database, Path) {}
    }
}