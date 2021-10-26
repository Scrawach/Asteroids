using Infrastructure.AssetManagement;
using StaticData;

namespace Infrastructure.StaticData
{
    public class PlayerInputConfig : Asset<PlayerInputData>
    {
        private const string Path = "StaticData/PlayerWeapon";
        public PlayerInputConfig(IAssetsDatabase database) : base(database, Path) { }
    }
}