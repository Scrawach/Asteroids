using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class CachedFactory : IObjectFactory
    {
        private readonly IObjectFactory _objectFactory;
        private GameObject _cachedObject;
        private bool _beenCached;

        public CachedFactory(IObjectFactory objectFactory) => 
            _objectFactory = objectFactory;

        public GameObject Create()
        {
            if (_beenCached)
                return _cachedObject;
            _cachedObject = _objectFactory.Create();
            _beenCached = false;
            return _cachedObject;
        }
    }
}