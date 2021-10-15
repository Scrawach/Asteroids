using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.AssetManagement;
using StaticData;

namespace Infrastructure.StaticData
{
    public class StaticDatabase : IStaticDatabase
    {
        private const string EnginePath = "StaticData/Engines";
        private const string PlayerInputPath = "StaticData/PlayerInputData";
        
        private readonly IAssetsDatabase _assetsDatabase;
        private Dictionary<EngineId, EngineConfig> _engines;
        private PlayerInputData _playerInputData;

        public StaticDatabase(IAssetsDatabase assetsDatabase) => 
            _assetsDatabase = assetsDatabase;

        public void Load()
        {
            _engines = _assetsDatabase
                .LoadAll<EngineConfig>(EnginePath)
                .ToDictionary(config => config.Id, data => data);
            _playerInputData = _assetsDatabase
                .Load<PlayerInputData>(PlayerInputPath);
        }

        public EngineConfig ForEngine(EngineId engineId)
        {
            if (_engines.TryGetValue(engineId, out var engineConfig))
                return engineConfig;
            throw new NotExistDataWithThisIdException();
        }

        public PlayerInputData ForPlayerInput() => 
            _playerInputData;

        private class NotExistDataWithThisIdException : Exception {}
    }
}