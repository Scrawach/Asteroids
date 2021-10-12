using System;
using Infrastructure.SceneManagement.Abstract;

namespace Infrastructure.SceneManagement
{
    public class SceneStorage : ISceneStorage
    {
        private readonly IAvailableScenes _availableScenes;

        public SceneStorage(IAvailableScenes availableScenes) => 
            _availableScenes = availableScenes;

        public ILoadingScene Get(string sceneName)
        {
            if (_availableScenes
                .Scenes()
                .TryGetValue(sceneName, out var scene))
                return scene;
            throw new NotFoundSceneException();
        }

        private class NotFoundSceneException : Exception { }
    }
}