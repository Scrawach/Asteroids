using System;
using System.Collections.Generic;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly Dictionary<ObjectId, IObjectFactory> _factories;

        public GameFactory(Dictionary<ObjectId, IObjectFactory> factories) => 
            _factories = factories;

        public GameObject Create(ObjectId objectId)
        {
            if (_factories.TryGetValue(objectId, out var factory))
                return factory.Create();
            throw new NotFoundSuitableFactoryException();
        }

        public void Dispose()
        {
            foreach (var pair in _factories)
                if (pair.Value is IDisposable disposable)
                    disposable.Dispose();
        }

        private class NotFoundSuitableFactoryException : Exception { }
    }
}