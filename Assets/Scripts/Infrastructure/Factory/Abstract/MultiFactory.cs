using UnityEngine;

namespace Infrastructure.Factory.Abstract
{
    public class MultiFactory : IObjectFactory
    {
        private readonly IObjectFactory[] _factories;

        public MultiFactory(params IObjectFactory[] factories) => 
            _factories = factories;


        public GameObject Create()
        {
            GameObject created = default;
            for (var i = 0; i < _factories.Length; i++)
                created = _factories[i].Create();
            return created;
        }
    }
}