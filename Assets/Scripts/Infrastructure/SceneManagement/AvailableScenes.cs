using System.Collections.Generic;
using System.Linq;
using Infrastructure.SceneManagement.Abstract;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneManagement
{
    public class AvailableScenes : IAvailableScenes
    {
        private readonly string[] _names;
        private readonly ISceneFactory _factory;

        public AvailableScenes(string[] names, ISceneFactory factory)
        {
            _names = names;
            _factory = factory;
        }

        public Dictionary<string, ILoadingScene> Scenes()
        {
            return _names
                .ToDictionary(name => name, 
                    value => _factory.Create(value));
        }
    }
}