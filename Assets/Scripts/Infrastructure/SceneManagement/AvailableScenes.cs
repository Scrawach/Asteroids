using System.Collections.Generic;
using System.Linq;
using Infrastructure.SceneManagement.Abstract;

namespace Infrastructure.SceneManagement
{
    public class AvailableScenes : IAvailableScenes
    {
        private readonly ISceneNames _sceneNames;
        private readonly ISceneFactory _factory;

        public AvailableScenes(ISceneNames sceneNames, ISceneFactory factory)
        {
            _sceneNames = sceneNames;
            _factory = factory;
        }

        public Dictionary<string, ILoadingScene> Scenes()
        {
            return _sceneNames.Names()
                .ToDictionary(name => name, 
                    value => _factory.Create(value));
        }
    }
}