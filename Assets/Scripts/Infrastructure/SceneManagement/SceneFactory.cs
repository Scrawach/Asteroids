using Infrastructure.SceneManagement.Abstract;

namespace Infrastructure.SceneManagement
{
    public class SceneFactory : ISceneFactory
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneFactory(ICoroutineRunner coroutineRunner) => 
            _coroutineRunner = coroutineRunner;

        public ILoadingScene Create(string name) => 
            new Scene(name, _coroutineRunner);
    }
}