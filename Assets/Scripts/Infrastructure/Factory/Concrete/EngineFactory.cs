using Components;
using Components.Player;
using Infrastructure.AssetManagement;
using Infrastructure.Factory.Abstract;
using Infrastructure.StaticData;
using StaticData;
using UnityEngine;

namespace Infrastructure.Factory.Concrete
{
    public class EngineFactory : IObjectFactory
    {
        private readonly IObjectFactory _factory;
        private readonly IAsset<EngineConfig> _config;

        public EngineFactory(IObjectFactory objectFactory, IAsset<EngineConfig> config)
        {
            _factory = objectFactory;
            _config = config;
        }

        public GameObject Create()
        {
            var obj = _factory.Create();
            var data = _config.Load();
            var engine = obj.GetComponent<Engine>();
            engine.Construct(data.MoveSpeed, data.RotateSpeed, data.AccelerationModifier);
            return obj;
        }
    }
}