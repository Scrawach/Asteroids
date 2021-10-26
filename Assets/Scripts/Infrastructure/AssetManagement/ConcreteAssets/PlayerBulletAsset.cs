using UnityEngine;

namespace Infrastructure.AssetManagement.ConcreteAssets
{
    public class PlayerBulletAsset :  Asset<GameObject>
    {
        private const string Path = "Weapon/Bullet";
        public PlayerBulletAsset(IAssetsDatabase database) : base(database, Path) {}
    }
}