using Infrastructure.Factory;
using StaticData;

namespace Infrastructure.StaticData
{
    public interface IStaticDatabase
    {
        void Load();
        EngineConfig ForEngine(EngineId engineId);
        PlayerInputData ForPlayerInput();
    }
}