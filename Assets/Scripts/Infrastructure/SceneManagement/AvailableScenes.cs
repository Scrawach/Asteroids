using System.Collections.Generic;
using System.Linq;
using Infrastructure.SceneManagement.Abstract;

namespace Infrastructure.SceneManagement
{
    public class AvailableScenes : IAvailableScenes
    {
        private readonly BuildSceneNames _buildSceneNames;
        private readonly ISceneFactory _factory;

        public AvailableScenes(BuildSceneNames buildSceneNames, ISceneFactory factory)
        {
            _buildSceneNames = buildSceneNames;
            _factory = factory;
        }

        public Dictionary<string, ILoadingScene> Scenes()
        {
            return _buildSceneNames.Content()
                .ToDictionary(name => name, 
                    value => _factory.Create(value));
        }
    }
}