using System.Collections.Generic;
using Infrastructure.SceneManagement.Abstract;

namespace Infrastructure.SceneManagement
{
    public class CachedAvailableScenes : IAvailableScenes
    {
        private readonly IAvailableScenes _scenes;

        private Dictionary<string, ILoadingScene> _cachedScenes;
        private bool _beenCached;

        public CachedAvailableScenes(IAvailableScenes scenes) => 
            _scenes = scenes;

        public Dictionary<string, ILoadingScene> Scenes()
        {
            if (_beenCached)
                return _cachedScenes;
            _cachedScenes = _scenes.Scenes();
            _beenCached = true;
            return _cachedScenes;
        }
    }
}