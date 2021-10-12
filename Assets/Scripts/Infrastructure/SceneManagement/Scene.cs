using System;
using System.Collections;
using Extensions;
using Infrastructure.SceneManagement.Abstract;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneManagement
{
    public class Scene : ILoadingScene
    {
        private readonly string _name;
        private readonly ICoroutineRunner _coroutineRunner;

        public Scene(string name, ICoroutineRunner coroutineRunner)
        {
            _name = name;
            _coroutineRunner = coroutineRunner;
        }
        
        public void Load(Action onLoaded = null)
        {
            if (IsSceneLoaded(_name))
                onLoaded?.Invoke();
            else
                _coroutineRunner.StartCoroutine(Loading(_name, onLoaded));
        }
        
        private static IEnumerator Loading(string sceneName, Action onLoaded = null)
        {
            var loading = SceneManager.LoadSceneAsync(sceneName);
            while (loading.NotDoneYet()) yield return null;
            onLoaded?.Invoke();
        }
        
        private static bool IsSceneLoaded(string scene) => 
            SceneManager.GetActiveScene().name == scene;
    }
}