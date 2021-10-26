using Components;
using Infrastructure.Factory.Abstract;
using Infrastructure.StaticData;
using StaticData;
using UnityEngine;

namespace Infrastructure.Factory.Concrete
{
    public class EngineFactory : IObjectFactory
    {
        private readonly IObjectFactory _factory;
        private readonly IStaticDatabase _database;

        public EngineFactory(IObjectFactory objectFactory, IStaticDatabase database)
        {
            _factory = objectFactory;
            _database = database;
        }

        public GameObject Create()
        {
            var obj = _factory.Create();
            var engineData = _database.ForEngine(EngineId.Player);
            obj.GetComponent<Engine>().Construct(engineData.MoveSpeed, 
                engineData.RotateSpeed, engineData.AccelerationModifier);
            return obj;
        }
    }
}