using Infrastructure.AssetManagement;
using StaticData;

namespace Infrastructure.StaticData
{
    public class PlayerWeaponConfig : Asset<WeaponConfig>
    {
        private const string Path = "StaticData/PlayerWeapon";
        public PlayerWeaponConfig(IAssetsDatabase database) : base(database, Path) { }
    }
}