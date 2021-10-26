using Infrastructure.AssetManagement;
using StaticData;

namespace Infrastructure.StaticData
{
    public class PlayerEngineConfig : Asset<EngineConfig>
    {
        private const string Path = "StaticData/Engines";
        public PlayerEngineConfig(IAssetsDatabase database) : base(database, Path) { }
    }
}