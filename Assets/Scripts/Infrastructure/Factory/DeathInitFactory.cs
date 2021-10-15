using Components;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class DeathObjectFactory : IObjectFactory
    {
        private readonly IObjectFactory _objectFactory;
        private readonly IObjectFactory _vfxFactory;

        public DeathObjectFactory(IObjectFactory objectFactory, IObjectFactory vfxFactory)
        {
            _objectFactory = objectFactory;
            _vfxFactory = vfxFactory;
        }
        
        public GameObject Create()
        {
            var obj = _objectFactory.Create();
            obj.GetComponent<Death>().Construct(_vfxFactory);
            return obj;
        }
    }
}