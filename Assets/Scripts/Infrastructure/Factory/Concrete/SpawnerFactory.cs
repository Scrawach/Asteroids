using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory.Concrete
{
    public class SpawnerFactory : IObjectFactory
    {
        private readonly IObjectFactory _objectFactory;
        private readonly IObjectFactory _spawnObject;
        private readonly float _cooldown;

        public SpawnerFactory(IObjectFactory objectFactory, IObjectFactory spawnObject, float cooldown)
        {
            _objectFactory = objectFactory;
            _spawnObject = spawnObject;
            _cooldown = cooldown;
        }
        
        public GameObject Create()
        {
            var obj = _objectFactory.Create();
            obj.GetComponent<Components.Environment.SpawnFactory>().Construct(_spawnObject, _cooldown);
            return obj;
        }
    }
}