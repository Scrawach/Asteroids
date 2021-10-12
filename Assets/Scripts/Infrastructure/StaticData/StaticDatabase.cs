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
        private readonly IAssetsDatabase _assetsDatabase;
        private Dictionary<EngineId, EngineConfig> _engines;

        public StaticDatabase(IAssetsDatabase assetsDatabase) => 
            _assetsDatabase = assetsDatabase;

        public void Load()
        {
            _engines = _assetsDatabase
                .LoadAll<EngineConfig>(EnginePath)
                .ToDictionary(config => config.Id, data => data);
        }

        public EngineConfig ForEngine(EngineId engineId)
        {
            if (_engines.TryGetValue(engineId, out var engineConfig))
                return engineConfig;
            throw new NotExistDataWithThisIdException();
        }

        private class NotExistDataWithThisIdException : Exception {}
    }
}